using Hospital.bll.Interface;
using Hospital.dll.Context;
using Hospital.dll.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospital.Web.Controllers
{
    public class HomeController : Controller
    {


        HospitalDBContext db = new HospitalDBContext();

        public ActionResult Index()
        {
            HomePageCount model = new HomePageCount
            {
                DoctorCount = db.Doctor.Count(),
                PatientCount = db.Patient.Count(),
                DepartmentCount = db.Department.Count(),


            };

            return View(model);
        }

        public ActionResult Search(string searchQuery)
        {
            List<Patient> patients = db.Patient.ToList();
            List<Doctor> doctors = db.Doctor.ToList();
            List<Department> departments = db.Department.ToList();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                char firstword = searchQuery.FirstOrDefault().ToString().ToLower()[0];

                patients = patients.Where(p => char.ToLower(p.PatientName[0]) == firstword).ToList();
                doctors = doctors.Where(d => char.ToLower(d.DoctorName[0]) == firstword).ToList();
                departments = departments.Where(d => char.ToLower(d.DepartmentName[0]) == firstword).ToList();

            }

            SearchViewModel searchViewModel = new SearchViewModel
            {
                Patient = patients,
                Doctor = doctors,
                Department = departments

            };

            return View(searchViewModel);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}