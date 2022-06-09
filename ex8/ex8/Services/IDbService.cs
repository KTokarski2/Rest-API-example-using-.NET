using ex8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ex8.Services
{
    interface IDbService
    {
        public List<Doctor> GetDoctor(int idDoctor);

    }
}
