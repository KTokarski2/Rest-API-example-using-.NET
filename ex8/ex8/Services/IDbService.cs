using ex8.DTOs;
using ex8.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ex8.Services
{
    interface IDbService
    {
        public Task<IActionResult> GetDoctors();
        public Task<IActionResult> AddDoctor(AddDoctorRequest request);
        public Task<IActionResult> DeleteDoctor(int idDoctor);
        public Task<IActionResult> ModifyDoctor(ModifyDoctorRequest request);
        public Task<IActionResult> GetPrescription(DownloadPrescriptionRequest request);

    }
}
