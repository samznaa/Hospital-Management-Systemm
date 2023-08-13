using Hospital.bll.Interface;
using Hospital.dll.Context;
using Hospital.dll.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Hospital.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartment _ID;


        public DepartmentController(IDepartment iD)
        {
            _ID = iD;
        }

        private HospitalDBContext db = new HospitalDBContext();



        // GET: Department
        public ActionResult Index()
        {
            Department model = new Department();
            model.Departmentlist = new List<Department>();
            model.Departmentlist = _ID.GetDepartmentList();
            return View(model);
        }

        // GET: Department/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Department department = _ID.FindById(id);
            if (department == null)
            {
                return HttpNotFound();
            }

            return View(department);
        }

        // GET: Department/Create
        public ActionResult Create()
        {
            Department department = new Department();
            return View(department);

        }

        // POST: Department/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _ID.CreateDepartment(department);

                return RedirectToAction("Index");
            }

            return View(department);
        }

        // GET: Department/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Department department = _ID.FindById(id);
            if (department == null)
            {
                return HttpNotFound();
            }

            return View(department);
        }

        // POST: Department/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                _ID.UpdateDepartment(department);

                return RedirectToAction("Index");
            }

            return View(department);
        }

        // GET: Department/Delwtw/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Department department = _ID.FindById(id);
            if (department == null)
            {
                return HttpNotFound();
            }

            return View(department);
        }


        // POST: Department/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Department department = _ID.FindById(id);
            _ID.DeleteDepartment(department);

            return RedirectToAction("Index");
        }
    }
}

