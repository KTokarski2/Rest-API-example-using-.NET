using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ex8.DTOs
{
    public class DownloadPrescriptionRequest
    {
        public int IdDoctor { get; set; }
        public int IdPatient { get; set; }
        public string Medicament { get; set; }
    }
}
