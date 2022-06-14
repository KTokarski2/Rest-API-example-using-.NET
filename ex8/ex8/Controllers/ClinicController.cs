using ex8.DTOs;
using ex8.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ex8.Controllers
{

    [ApiController]
    [Route("api/")]
    public class ClinicController : ControllerBase
    {
        private readonly IDbService _dbService;

        public ClinicController(DbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("doctors")]
        public async Task<IActionResult> GetDoctor()
        {
            return await _dbService.GetDoctors();
        }

        [HttpPost("doctor")]
        public async Task<IActionResult> AddDoctor(AddDoctorRequest addDoctorRequest)
        {
            return await _dbService.AddDoctor(addDoctorRequest);
        }

        [HttpDelete("doctor/{idDoctor}")]
        public async Task<IActionResult> DeleteDoctor(int idDoctor)
        {
            return await _dbService.DeleteDoctor(idDoctor);
        }

        [HttpPut("doctor/{idDoctor")]
        public async Task<IActionResult> UpdateDoctor(ModifyDoctorRequest modifyDoctorRequest)
        {
            return await _dbService.ModifyDoctor(modifyDoctorRequest);
        }

        [HttpGet("prescription")]
        public async Task<IActionResult> GetPrescription(DownloadPrescriptionRequest downloadPrescriptionRequest)
        {
            return await _dbService.GetPrescription(downloadPrescriptionRequest);
        }
    }
}
