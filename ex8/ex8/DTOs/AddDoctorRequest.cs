using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ex8.DTOs
{
    public class AddDoctorRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
