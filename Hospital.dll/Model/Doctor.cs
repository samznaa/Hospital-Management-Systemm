using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Hospital.dll.Model
{

    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string Experience { get; set; }
        public string Qualification { get; set; }
        [Display(Name = "Department Name")]
        public int? DepartmentId { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public string DoctorImage { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        [NotMapped]
        public List<Doctor> Doctorlist { get; set; }
        [NotMapped]
        public string FileName { get; set; }
    }
}


