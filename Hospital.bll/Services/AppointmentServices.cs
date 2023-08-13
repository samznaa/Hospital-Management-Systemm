using Hospital.bll.Interface;
using Hospital.dll.Context;
using Hospital.dll.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.bll.Services
{
    public class AppointmentServices : IAppointment
    {
        private readonly HospitalDBContext _db;

        public AppointmentServices(HospitalDBContext db)
        {
            _db = db;
        }

        //public List<Appointment> GetAppointmentList(int? AppointmentId)
        //{
        //    if (AppointmentId.HasValue)
        //        return _db.Appointment.Where(a => a.AppointmentId == AppointmentId.Value).ToList();
        //    else
        //        return _db.Appointment.ToList();
        //}

        public string CreateAppointment(Appointment appointment)
        {
            try
            {
                _db.Appointment.Add(appointment);
                _db.SaveChanges();
                return "Appointment created successfully.";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }

        public string UpdateAppointment(Appointment appointment)
        {
            try
            {
                _db.Entry(appointment).State = EntityState.Modified;
                _db.SaveChanges();
                return "Appointment updated successfully.";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }

        //public string DeleteAppointment(Appointment appointment)
        //{
        //    try
        //    {
        //        _db.Appointment.Remove(appointment);
        //        _db.SaveChanges();
        //        return "Appointment deleted successfully.";
        //    }
        //    catch (Exception e)
        //    {
        //        return e.Message.ToString();
        //    }
        //}

        public Appointment FindById(int? id)
        {
            Appointment appointment = _db.Appointment.Find(id);
            return appointment;
        }
        public List<Appointment> GetAppointmentList()
        {
            return _db.Appointment.ToList();
        }


    }
}