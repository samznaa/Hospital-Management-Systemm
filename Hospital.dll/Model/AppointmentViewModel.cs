using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.dll.Model
{
    public class AppointmentViewModel
    {
        [Required(ErrorMessage = "Please enter the note.")]
        public string Note { get; set; }


        [Required(ErrorMessage = "Please select the doctor.")]
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}
