using Hospital.dll.Model;
using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.bll.Interface
{

    public interface IPatient
    {
        List<Patient> GetPatientList(int? PatientId);
        string CreatePatient(Patient patient);
        string UpdatePatient(Patient patient);
        string DeletePatient(Patient PatientId);
        Patient FindById(int? id);
        List<Patient> GetPatientList();
       
    }
}