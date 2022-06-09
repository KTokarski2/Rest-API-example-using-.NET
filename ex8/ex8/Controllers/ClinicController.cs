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
        private readonly DbService _dbService;

        public ClinicController(DbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("doctor/{idDoctor}")]
        public IActionResult GetDoctors(int idDoctor)
        {
            return Ok(_dbService.GetDoctor(idDoctor));
        }
    }
}
