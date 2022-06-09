using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ex8.Models
{
    public class Patient
    {
        
        public int IdPatient { get; set; }
        
        public string FristName { get; set; }
        
        public string LastName { get; set; }
        
        public DateTime BirthDate { get; set; }
        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}
