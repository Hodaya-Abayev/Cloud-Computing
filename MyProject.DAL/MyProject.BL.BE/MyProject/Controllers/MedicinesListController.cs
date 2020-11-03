using MyProject.BL.BE;
using MyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProject.Controllers
{
    public class MedicinesListController : Controller
    {
        // GET: MedicinesList
        public ActionResult Index()
        {
            MedicineModel Model = new MedicineModel();
            MedicineViewModel viewModel = new MedicineViewModel(Model.GetList());
            return View(viewModel.GetList());
        }
        [HttpPost]
        public ActionResult Create()
        {
            return RedirectToAction("Create", "Charts");
        }

        // GET: MedicinesList/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult CreateNew()
        {
            Medicine medicine = new Medicine();
            MedicineViewModel Model = new MedicineViewModel(medicine);
            return View(Model);
        }
        [HttpPost]
        public ActionResult CreateNew(Medicine medicine)
        {
            MedicineModel Model = new MedicineModel();
            Model.CreateNew(medicine);
            if (Request.Form["Create"] != null)
                return RedirectToAction("Index");
            else
            {
                TempData["medicine"] = medicine;
                return RedirectToAction("Check", "Image");
            }
            
        }




        // POST: MedicinesList/Create
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

        // GET: MedicinesList/Edit/5
        public ActionResult Edit(int id)
        {
            MedicineModel Model = new MedicineModel();
            Medicine medicine = new Medicine(Model.GetMedicineById(id));
            TempData["medicine"] = medicine;
            return RedirectToAction("Check", "Image");
        }

        // POST: MedicinesList/Edit/5
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

        // GET: MedicinesList/Delete/5
        public ActionResult Delete(int id)
        {
            MedicineModel Model = new MedicineModel();
            Medicine medicine = new Medicine(Model.GetMedicineById(id));
            MedicineViewModel viewModel = new MedicineViewModel(medicine);
            
            return View(viewModel);

        }

        // POST: MedicinesList/Delete/5

        //[HttpGet]
        [HttpPost]
        public ActionResult Delete(Medicine m)
        {
           
            MedicineModel Model = new MedicineModel();
            Medicine medicine = new Medicine(Model.GetMedicineById(m.ID));
            Model.Delete(medicine);
            return RedirectToAction("Index");
        }
    }
}
