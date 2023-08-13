using Hospital.dll.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.bll.Interface
{

    public interface IDepartment
    {


        List<Department> GetDepartmentList(int? DepartmentId);
        string CreateDepartment(Department department);
        string UpdateDepartment(Department department);
        string DeleteDepartment(Department DepartmentId);
        Department FindById(int? id);
        List<Department> GetDepartmentList();
    }
}








