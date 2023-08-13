using Hospital.bll.Interface;
using Hospital.dll.Context;
using Hospital.dll.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Hospital.web.Controllers
{
    public class AppointmentController : Controller
    {

        private readonly IDoctor _ID;
        private readonly IAppointment _IA;

        public AppointmentController(IDoctor iD, IAppointment iA)
        {
            _ID = iD;
            _IA = iA;
        }
        private HospitalDBContext db = new HospitalDBContext();

        
        public ActionResult Index()
        {
            Appointment model = new Appointment();
            model.Appointmentlist = new List<Appointment>();
            model.Appointmentlist = _IA.GetAppointmentList();
            return View(model);
        }

        // GET: Appointment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Appointment appointment = _IA.FindById(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }

            return View(appointment);
        }

        // GET: Appointment/Create
        public ActionResult Create()
        {
            Appointment appointment = new Appointment();
            return View(appointment);
         
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Appointment appointment, HttpPostedFileBase ImageFile)
        {
            // Handle image file upload

            if (ModelState.IsValid)
            {

                _IA.CreateAppointment(appointment);

                return RedirectToAction("Index");
            }

            return View(appointment);
        }

        public ActionResult ViewAppointment()
        {
            var appointmentList= _IA.GetAppointmentList();
            return View(appointmentList);
        }
        [HttpGet]
        public ActionResult IsConfirmed(int id)
        {
            var appointment = _IA.FindById(id);

            if (appointment == null)
            {
                return HttpNotFound(); // Handle the case when the appointment is not found
            }

            appointment.IsConfirmed = true;
            appointment.IsDeclined = false;

            _IA.UpdateAppointment(appointment);

            return RedirectToAction("ViewAppointment"); // Redirect back to the appointment list
        }

        [HttpPost]
        public ActionResult IsDeclined(int id)
        {
            var appointment = _IA.FindById(id);

            if (appointment == null)
            {
                return HttpNotFound(); // Handle the case when the appointment is not found
            }

            appointment.IsDeclined = true;
            appointment.IsConfirmed = false;

            _IA.UpdateAppointment(appointment);

            return RedirectToAction("ViewAppointment"); // Redirect back to the appointment list
        }
    }
}
