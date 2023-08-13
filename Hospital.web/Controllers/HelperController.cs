using Hospital.dll.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospital.web.Controllers
{
    public class HelperController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public class SelectListVM
        {
            public int Id { get; set; }

            public string Idstr { get; set; }
            public string Title { get; set; }

            public int DepartmentId { get; set; }
            public string DoctorId { get; set; }
        }
        public ActionResult GetDoctorByDepartmentIdDD(int? id)
        {
            using (HospitalDBContext db = new HospitalDBContext())
            {

                List<SelectListItem> ddlList = new List<SelectListItem>();
                var collection = db.Database.SqlQuery<SelectListVM>(@"select DoctorId as Id, DoctorName as Title from Doctor where DepartmentId='" + id + "'").ToList();
                ddlList.Add(new SelectListItem { Text = "--Select--", Value = "0", Selected = true });
                foreach (var item in collection)
                {
                    ddlList.Add(new SelectListItem { Text = item.Title.ToString(), Value = item.Id.ToString() });
                }
                var ddlSelectOptionList = ddlList;


                return Json(ddlSelectOptionList, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
