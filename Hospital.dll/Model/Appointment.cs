using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Hospital.dll.Model
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }

        [Required]
        public int DoctorId { get; set; }
        [NotMapped]
        public string DoctorName { get; set; }
        [NotMapped]
        public virtual Doctor Doctor { get; set; }

        [Required]
        public int PatientId { get; set; }
        [NotMapped]
        public string PatientName { get; set; }
        [NotMapped]
        public virtual Patient Patient { get; set; }

        [Required]
        [Display(Name = "Appointment Date")]
        public DateTime AppointmentDate { get; set; }
      
        [Required(ErrorMessage = "Please enter the Appointment note.")]
        public string Note { get; set; }


        [Required]
        public bool IsConfirmed { get; set; }
        [Required]
        public bool IsDeclined { get; set; }

        [NotMapped]
        public List<Appointment> Appointmentlist { get; set; }
    }


    public class AppointmentVm
    {
        public int AppointmentId { get; set; }

        public int PatientId { get; set; }


        public int DoctorId { get; set; }

        public string PatientName { get; set; }

        public string DoctorName { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsDeclined { get; set; }



        public string Note { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}




