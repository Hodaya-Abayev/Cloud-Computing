using MyProject.BL.BE;
using MyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProject.Controllers
{
    public class DoctorController : Controller
    {
        // GET: Doctor
        public ActionResult Index()
        {
            return View();
        }

        // GET: Doctor/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Doctor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Doctor/Create
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
        //public ActionResult Check()
        //{
        //    Doctor doctor = new Doctor();
        //    return Check("אבי אדם כהן");
        //}
        [HttpGet]
        
        public ActionResult Check()
        {
            var doctor = (Doctor)TempData["doctor"];
            DoctorModel Model = new DoctorModel();
            if (Model.isLicense(doctor.Name))
                return RedirectToAction("NoLicense");
            else
            {
                
                return RedirectToAction("Create", "Patient");
            }

        }

        
        public ActionResult NoLicense()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ThereIsLicense()
        {
            var prescription = (Prescription)TempData["prescription"];
            return RedirectToAction("Check", "Interactions");
        }
        [HttpGet]
        // GET: Doctor/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Doctor/Edit/5
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

        // GET: Doctor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Doctor/Delete/5
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

