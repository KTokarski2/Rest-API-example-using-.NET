using ex8.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ex8.Services
{
    public class DbService : IDbService
    {
        private MainDbContext _context;

        public DbService(MainDbContext context)
        {
            _context = context;
        }

        public List<Doctor> GetDoctor(int idDoctor)
        {

            List<Doctor> list = _context.Doctors.Where(d => d.IdDoctor == idDoctor).ToList();
            return list;

        }
    }
}
