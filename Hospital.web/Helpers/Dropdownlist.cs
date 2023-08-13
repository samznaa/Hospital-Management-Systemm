using Hospital.dll.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospital.Web.Helpers
{
    public class DropdownList
    {
        public static string DepartmentName { get; set; }
        public static string DoctorName { get; set; }
        public static string PatientName { get; set; }

        public class SelectListModelFunctionClass
        {
            public int Id { get; set; }

            public int DoctorId { get; set; }
            public int PatientId { get; set; }
            public string Title { get; set; }

            public string DoctorName { get; set; }

            public int DepartmentId { get; set; }

        }

        public static SelectList GetDepartmentDD()
        {
            using (HospitalDBContext db = new HospitalDBContext())
            {
                List<SelectListItem> ddlist = new List<SelectListItem>();
                var collection = db.Database.SqlQuery<SelectListModelFunctionClass>(@"select DepartmentId as Id, DepartmentName as Title from Department").ToList();

                ddlist.Add(new SelectListItem { Text = "--Select--", Value = "0" });
                foreach (var item in collection)
                {

                    ddlist.Add(new SelectListItem { Text = item.Title, Value = item.Id.ToString() });
                }

                return new SelectList(ddlist.ToList(), "Value", "Text");
            }

        }


        public static SelectList GetDoctorDD()
        {
            using (HospitalDBContext db = new HospitalDBContext())
            {
                List<SelectListItem> ddlist = new List<SelectListItem>();
                var collection = db.Database.SqlQuery<SelectListModelFunctionClass>(@"select DoctorId as Id, DoctorName as Title from Doctor").ToList();

                ddlist.Add(new SelectListItem { Text = "--Select--", Value = "0" });
                foreach (var item in collection)
                {

                    ddlist.Add(new SelectListItem { Text = item.Title, Value = item.Id.ToString() });
                }

                return new SelectList(ddlist.ToList(), "Value", "Text");
            }

        }
    }
}