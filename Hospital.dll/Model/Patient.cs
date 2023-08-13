using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.dll.Model
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Status { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        [Display(Name = "Department Name")]
        public int? DepartmentId { get; set; }

        [Display(Name = "Doctor Name")]
        public int? DoctorId { get; set; }
        [NotMapped]
        public List<Patient> Patientlist { get; set; }

        public string UserId { get; set; }

    }
}