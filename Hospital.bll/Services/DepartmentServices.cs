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
    public class DepartmentServices : IDepartment
    {
        private readonly HospitalDBContext _db;

        public DepartmentServices(HospitalDBContext db)
        {
            _db = db;
        }

        public List<Department> GetDepartmentList(int? DepartmentId)
        {
            if (DepartmentId.HasValue)
                return _db.Department.Where(a => a.DepartmentId == DepartmentId.Value).ToList();
            else
                return _db.Department.ToList();
        }

        public string CreateDepartment(Department department)
        {
            try
            {
                _db.Department.Add(department);
                _db.SaveChanges();
                return "Appointment created successfully.";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }

        public string UpdateDepartment(Department department)
        {
            try
            {
                _db.Entry(department).State = EntityState.Modified;
                _db.SaveChanges();
                return "Appointment updated successfully.";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }

        public string DeleteDepartment(Department department)
        {
            try
            {
                _db.Department.Remove(department);
                _db.SaveChanges();
                return "Department deleted successfully.";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }

        public Department FindById(int? id)
        {
            Department department = _db.Department.Find(id);
            return department;
        }
        public List<Department> GetDepartmentList()
        {
            return _db.Department.ToList();
        }


    }
}