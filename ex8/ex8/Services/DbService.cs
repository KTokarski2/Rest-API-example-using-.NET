using ex8.DTOs;
using ex8.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ex8.Services
{
    public class DbService : IDbService
    {
        private IMainDbContext _context;

        public DbService(IMainDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> GetDoctors()
        {
            return new OkObjectResult(await _context.Doctors.ToListAsync());
        }

        public async Task<IActionResult> AddDoctor(AddDoctorRequest addDoctorRequest)
        {
            var Doctor = new Doctor()
            {
                FristName = addDoctorRequest.FirstName,
                LastName = addDoctorRequest.LastName,
                Email = addDoctorRequest.Email
            };

            await _context.Doctors.AddAsync(Doctor);
            await _context.SaveChangesAsync();
            return new OkObjectResult($"New doctor has been added to database");

        }

        public async Task<IActionResult> DeleteDoctor(int IdDoctor)
        {
            if (!await CheckDoctor(IdDoctor)) 
                return new BadRequestObjectResult($"Doctor with given id does not exist in database");

            _context.Doctors.Remove(await _context.Doctors.SingleOrDefaultAsync(d => d.IdDoctor == IdDoctor));
            await _context.SaveChangesAsync();

            return new OkObjectResult($"Doctor with given id was succesfuly deleted from database");

        }

        public async Task<IActionResult> ModifyDoctor(ModifyDoctorRequest modifyDoctorRequest)
        {
            if (!await CheckDoctor(modifyDoctorRequest.IdDoctor)) 
                return new BadRequestObjectResult($"Doctor with given id does not exist in database");

            var doctor = await _context.Doctors.SingleOrDefaultAsync(d => d.IdDoctor == modifyDoctorRequest.IdDoctor);
            doctor.FristName = modifyDoctorRequest.FirstName;
            doctor.LastName = modifyDoctorRequest.LastName;
            doctor.Email = modifyDoctorRequest.Email;
            await _context.SaveChangesAsync();
            return new OkObjectResult("Doctor with given id was modified succesfully");
        }

        public async Task<IActionResult> GetPrescription(DownloadPrescriptionRequest downloadPrescriptionRequest)
        {
            if (!await CheckDoctor(downloadPrescriptionRequest.IdDoctor)) 
                return new BadRequestObjectResult($"Doctor with given id does not exist in database");
            if (!await CheckPatient(downloadPrescriptionRequest.IdPatient)) 
                return new BadRequestObjectResult($"Patient with given id does not exist in databse");
            if (!await CheckMedicament(downloadPrescriptionRequest.Medicament)) 
                return new BadRequestObjectResult($"Medicament with given id does not exist in database");

            var prescription = await _context.Prescriptions
                    .Where(p => p.IdDoctor == downloadPrescriptionRequest.IdDoctor && p.IdPatient == downloadPrescriptionRequest.IdPatient)
                    .SingleOrDefaultAsync();

            var medicament = await _context.Medicaments
                    .Where(m => m.Name == downloadPrescriptionRequest.Medicament)
                    .SingleOrDefaultAsync();

            var response = await _context.Prescriptions
                    .Where(p => p.IdDoctor == downloadPrescriptionRequest.IdDoctor && p.IdPatient == downloadPrescriptionRequest.IdPatient)
                    .Select(p => new DownloadPrescriptionResponse
                    {
                        Medicament = medicament.Name,
                        Date = prescription.Date,
                        DueDate = prescription.DueDate
                    }).ToListAsync();

            return new OkObjectResult(response);
        }
        
        private async Task<bool> CheckDoctor(int id)
        {
            return await _context.Doctors
                .AnyAsync(p => p.IdDoctor == id);
        }
        private async Task<bool> CheckPatient(int id)
        {
            return await _context.Patients
                .AnyAsync(p => p.IdPatient == id);
        }
        private async Task<bool> CheckMedicament(string name)
        {
            return await _context.Medicaments
                .AnyAsync(p => p.Name == name);
        }
    }
}
