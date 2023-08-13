using Hospital.dll.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.bll.Interface
{
    public interface IDoctor
    {
        List<Doctor> GetDoctorList(int? DoctorId);
        string CreateDoctor(Doctor doctor);
        string UpdateDoctor(Doctor doctor);
        string DeleteDoctor(Doctor DoctorId);
        Doctor FindById(int? id);
        List<Doctor> GetDoctorList();
    }
}