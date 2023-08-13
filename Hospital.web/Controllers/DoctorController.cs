using Hospital.bll.Interface;
using Hospital.dll.Context;
using Hospital.dll.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Web.UI.WebControls;

namespace Hospital.Web.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctor _ID;
        private readonly IAppointment _IA;

        public DoctorController(IDoctor iD, IAppointment iA)
        {
            _ID = iD;
            _IA = iA;
        }
        private HospitalDBContext db = new HospitalDBContext();

        // GET: Doctor
        public ActionResult Index()
        {
            Doctor model = new Doctor();
            model.Doctorlist = new List<Doctor>();
            model.Doctorlist = _ID.GetDoctorList();
            return View(model);
        }

        // GET: Doctor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Doctor doctor = _ID.FindById(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }

            return View(doctor);
        }

        // GET: Doctor/Create
        public ActionResult Create()
        {
            Doctor doctor = new Doctor();
            return View(doctor);
            //List<Doctor> doctorlist = new List<Doctor>();
            //return View(doctorlist);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Doctor doctor, HttpPostedFileBase ImageFile)
        {
            // Handle image file upload
            if (ImageFile != null && ImageFile.ContentLength > 0)
            {
                string fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                string extension = Path.GetExtension(ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
                doctor.DoctorImage = "../Image/" + fileName; // Relative image path
                fileName = Path.Combine(Server.MapPath("~/Image"), fileName);
                ImageFile.SaveAs(fileName); // Save the image to the server
            }

            if (ModelState.IsValid)
            {

                _ID.CreateDoctor(doctor); // Create the doctor
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(doctor);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = _ID.FindById(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Doctor doctor, HttpPostedFileBase ImageFile)
        {
            if (ImageFile != null && ImageFile.ContentLength > 0)
            {
                string fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                string extension = Path.GetExtension(ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
                doctor.DoctorImage = "../Image/" + fileName; // Relative image path
                fileName = Path.Combine(Server.MapPath("~/Image"), fileName);
                ImageFile.SaveAs(fileName); // Save the image to the server
            }
            if (ModelState.IsValid)
            {
                _ID.UpdateDoctor(doctor);
                return RedirectToAction("Index", new { @id = doctor.DoctorId });
                db.SaveChanges();
            }
            return View(doctor);
        }

        // GET: Doctor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Doctor doctor = _ID.FindById(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }

            return View(doctor);
        }

        // POST: Doctor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Doctor doctor = _ID.FindById(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }

            _ID.DeleteDoctor(doctor); // Delete the doctor
            db.SaveChanges();

            return RedirectToAction("Index");
        }



    }
}

