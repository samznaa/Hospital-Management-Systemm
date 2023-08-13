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
    public class DoctorServices : IDoctor
    {
        private readonly HospitalDBContext _db;

        public DoctorServices(HospitalDBContext db)
        {
            _db = db;
        }



        public string CreateDoctor(Doctor doctor)
        {
            try
            {
                _db.Doctor.Add(doctor);
                _db.SaveChanges();
                return "Doctor created successfully.";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }

        public string UpdateDoctor(Doctor doctor)
        {
            try
            {
                _db.Entry(doctor).State = EntityState.Modified;
                _db.SaveChanges();
                return "Doctor updated successfully.";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }

        public string DeleteDoctor(Doctor doctor)
        {
            try
            {
                _db.Doctor.Remove(doctor);
                _db.SaveChanges();
                return "Doctor deleted successfully.";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }
        public List<Doctor> GetDoctorList(int? DoctorId)
        {
            if (DoctorId.HasValue)
                return _db.Doctor.Where(d => d.DoctorId == DoctorId.Value).ToList();
            else
                return _db.Doctor.ToList();
        }

        public Doctor FindById(int? id)
        {
            Doctor doctor = _db.Doctor.Find(id);
            return doctor;
        }
        public List<Doctor> GetDoctorList()
        {
            return _db.Doctor.ToList();
        }




        public List<Appointment> GetAppointmentList()
        {
            using (HospitalDBContext db = new HospitalDBContext())
            {
                List<Appointment> AppointmentList = new List<Appointment>();

                AppointmentList = db.Database.SqlQuery<Appointment>("exec [dbo].[Appointment]").ToList();

                return AppointmentList;
            }
        }
    }
}