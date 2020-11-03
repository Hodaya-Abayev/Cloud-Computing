using MyProject.BL.BE;
using MyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProject.Controllers
{
    public class InteractionsController : Controller
    {
        // GET: Interactions
        public ActionResult Index()
        {
            return View();
        }

        // GET: Interactions/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Interactions/Create
        public ActionResult Create()
        {
            return View();
        }

        

            
        //}
        
        [HttpGet]
        public ActionResult Check()
        {
            var prescription = (Prescription)TempData["prescription"];
            var medicines = (List<MedicineTimes>)TempData["medicines"];
            MedicineModel Model = new MedicineModel();
            List<string> descriptions = Model.Interactions(medicines,prescription);
            TempData["descriptions"] = descriptions;
            if (descriptions.Any())
                return RedirectToAction("Warning");
            else
            {
                TempData["medicines"] = medicines;
                TempData["prescription"] = prescription;
                return RedirectToAction("Finish");
            }

        }
        [HttpGet]
        public ActionResult Warning()
        {
           
            var descriptions = TempData["descriptions"];
            return View(descriptions);
        }
        [HttpGet]
        public ActionResult Finish()
        {
            var medicines = (List<MedicineTimes>)TempData["medicines"];
            var prescription = (Prescription)TempData["prescription"];
            PrescriptionModel Model = new PrescriptionModel();
            Model.AddPrescription(medicines,prescription);
            Model.AddListMedicines(medicines, prescription);
            return View();
        }

        // POST: Interactions/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Interactions/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Interactions/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Interactions/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Interactions/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
