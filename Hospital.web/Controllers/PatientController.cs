using Hospital.bll.Interface;
using Hospital.dll.Context;
using Hospital.dll.Model;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Hospital.Web.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatient _IP;

        public PatientController(IPatient iP)
        {
            _IP = iP;


        }


        private HospitalDBContext db = new HospitalDBContext();


        // GET: Patient
        public ActionResult Index()
        {
            Patient model = new Patient();
            model.Patientlist = new List<Patient>();
            model.Patientlist = _IP.GetPatientList();
            return View(model);


        }



        // GET: Patient/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = _IP.FindById(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // GET: Patient/Create
        public ActionResult Create()
        {
            Patient patient = new Patient();
            return View(patient);
            //List<Patient> patientlist = new List<Patient>();
            //return View(patientlist);
        }

        // POST: Patient/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Patient patient)
        {
            if (ModelState.IsValid)
            {

                _IP.CreatePatient(patient);

                return RedirectToAction("Index");
            }

            return View(patient);
        }


        // GET: Patient/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = _IP.FindById(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patient/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Patient patient)
        {
            if (ModelState.IsValid)
            {
                _IP.UpdatePatient(patient);

                return RedirectToAction("Index");
            }
            return View(patient);
        }
        // GET: Patient/Patient/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Patient patient = _IP.FindById(id);
            if (patient == null)
            {
                return HttpNotFound();
            }

            return View(patient);
        }


        // POST: Doctor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Patient patient = _IP.FindById(id);
            _IP.DeletePatient(patient);

            return RedirectToAction("Index");
        }


        public ActionResult SubmitAppointment()
        {
            ViewBag.DoctorList = new SelectList(db.Doctor, "DoctorId", "DoctorName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitAppointment(AppointmentViewModel viewModel)
        {
            var UserId = User.Identity.GetUserId();
            var model = db.Patient.FirstOrDefault(x => x.UserId == UserId);

            if (model != null)
            {
                var appointment = new Appointment
                {
                    PatientId = model.PatientId,
                    DoctorId = viewModel.DoctorId,
                    Note = viewModel.Note,
                    //AppointmentDate = DateTime.Now
                };

                db.Appointment.Add(appointment);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.DoctorList = new SelectList(db.Doctor, "DoctorId", "DoctorName");
            return View(viewModel);
        }
    }
}
