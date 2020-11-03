using MyProject.BL.BE;
using MyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProject.Controllers
{
    public class PatientsListController : Controller
    {
        // GET: PatientsList
        public ActionResult Index()
        {
            PatientModel Model = new PatientModel();
            PatientViewModel viewModel = new PatientViewModel(Model.GetList());
            return View(viewModel.GetList());
        }

        // GET: PatientsList/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PatientsList/Create
        public ActionResult Create()
        {
            Patient patient = new Patient();
            PatientViewModel viewModel = new PatientViewModel(patient);
            return View(viewModel);
        }

        // POST: PatientsList/Create
        [HttpPost]
        public ActionResult Create(Patient patient)
        {
            PatientModel Model = new PatientModel();
            Model.CreateNew(patient);
            return RedirectToAction("Index");
        }

        // GET: PatientsList/Edit/5
        public ActionResult Edit(int id)
        {
            PatientModel Model = new PatientModel();
            Patient patient = new Patient(Model.GetPatient(id));
            PatientViewModel viewModel = new PatientViewModel(patient);
      
            return View(viewModel);
        }

        // POST: PatientsList/Edit/5
        [HttpPost]
        public ActionResult Edit(Patient patient)
        {
            PatientModel Model = new PatientModel();
            Model.Edit(patient);
            return RedirectToAction("Index");
        }

        // GET: PatientsList/Delete/5
        public ActionResult Delete(int id)
        {
            PatientModel Model = new PatientModel();
            Patient patient = new Patient(Model.GetPatient(id));
            PatientViewModel viewModel = new PatientViewModel(patient);
            //TempData["patient"] = patient;
            return View(viewModel);
        }

        // POST: PatientsList/Delete/5
        [HttpPost]
        
        public ActionResult Delete(Patient p)
        {
            //var patient = (Patient)TempData["patient"];
            PatientModel Model = new PatientModel();
            Patient patient = new Patient(Model.GetPatient(p.ID));
            Model.Delete(patient);
            return RedirectToAction("Index");
        }
    }
}
