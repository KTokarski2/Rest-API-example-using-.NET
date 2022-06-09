using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ex8.Models
{
    public class Doctor
    {   
        public int IdDoctor { get; set; }
        
        
        public string FristName { get; set; }
        
        
        public string LastName { get; set; }
        
        
        public string Email { get; set; }

        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}
