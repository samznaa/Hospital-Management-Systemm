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
    public class PatientServices : IPatient
    {
        private readonly HospitalDBContext _db;

        public PatientServices(HospitalDBContext db)
        {
            _db = db;
        }

        public List<Patient> GetPatientList(int? PatientId)
        {
            if (PatientId.HasValue)
                return _db.Patient.Where(p => p.PatientId == PatientId.Value).ToList();
            else
                return _db.Patient.ToList();
        }

        public string CreatePatient(Patient patient)
        {
            try
            {
                _db.Patient.Add(patient);
                _db.SaveChanges();
                return "Patient created successfully.";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }

        public string UpdatePatient(Patient patient)
        {
            try
            {
                _db.Entry(patient).State = EntityState.Modified;
                _db.SaveChanges();
                return "Patient updated successfully.";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }

        public string DeletePatient(Patient patient)
        {
            try
            {
                _db.Patient.Remove(patient);
                _db.SaveChanges();
                return "Patient deleted successfully.";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }

        public Patient FindById(int? id)
        {
            Patient patient = _db.Patient.Find(id);
            return patient;
        }
        public List<Patient> GetPatientList()
        {
            return _db.Patient.ToList();
        }




    }
}