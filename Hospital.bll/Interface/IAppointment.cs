using Hospital.dll.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.bll.Interface
{
    public interface IAppointment
    {


        //List<Appointment> GetAppointmentList(int? AppointmentId);
        string CreateAppointment(Appointment appointment);
        string UpdateAppointment(Appointment appointment);
        //string DeleteAppointment(Appointment AppointmentId);
        Appointment FindById(int? id);
        List<Appointment> GetAppointmentList();
    }
}













