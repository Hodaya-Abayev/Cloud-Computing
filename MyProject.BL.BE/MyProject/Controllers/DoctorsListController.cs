using MyProject.BL.BE;
using MyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProject.Controllers
{
    public class DoctorsListController : Controller
    {
        // GET: DoctorsList
        public ActionResult Index()
        {
            DoctorModel Model = new DoctorModel();
            DoctorViewModel viewModel = new DoctorViewModel(Model.GetList());
            return View(viewModel.GetList());
           
        }

        // GET: DoctorsList/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DoctorsList/Create
        public ActionResult Create()
        {
            Doctor doctor = new Doctor();
            DoctorViewModel viewModel = new DoctorViewModel(doctor);
            return View(viewModel);
        }

        // POST: DoctorsList/Create
        [HttpPost]
        public ActionResult Create(Doctor doctor)
        {
            DoctorModel Model = new DoctorModel();
            Model.CreateNew(doctor);
            return RedirectToAction("Index");
        }

        // GET: DoctorsList/Edit/5
        public ActionResult Edit(int id)
        {
            DoctorModel Model = new DoctorModel();
            Doctor doctor = new Doctor(Model.GetDoctor(id));
            DoctorViewModel viewModel= new DoctorViewModel(doctor);
            return View(viewModel);
        }

        // POST: DoctorsList/Edit/5
        [HttpPost]
        public ActionResult Edit(Doctor doctor)
        {
            DoctorModel Model = new DoctorModel();
            Model.Edit(doctor);
            return RedirectToAction("Index");
            
        }

        // GET: DoctorsList/Delete/5
        public ActionResult Delete(int id)
        {
            DoctorModel Model = new DoctorModel();
            Doctor doctor = new Doctor(Model.GetDoctor(id));
            DoctorViewModel viewModel = new DoctorViewModel(doctor);
            //TempData["doctor"] = doctor;
            return View(viewModel);
        }

        // POST: DoctorsList/Delete/5
        [HttpPost]
        //[HttpGet]
        public ActionResult Delete(Doctor d)
        {
            //var doctor = (Doctor)TempData["doctor"];
            DoctorModel Model = new DoctorModel();
            Doctor doctor = new Doctor(Model.GetDoctor(d.ID));
            
            Model.Delete(doctor);
            return RedirectToAction("Index");
        }
    }
}
