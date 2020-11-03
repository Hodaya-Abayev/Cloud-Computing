using MyProject.BL;
using MyProject.BL.BE;
using MyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProject.Controllers
{
    public class ImageController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Check()
        {
            MedicineImage img = new MedicineImage(string.Empty);
            return View(img);
        }

        
        [HttpPost]
        public ActionResult Check(FormCollection collection)
        {
            
            MedicineImageModel Model = new MedicineImageModel();
            string filePath = Server.MapPath(Url.Content($"~/images/{collection["imageFile"].ToString()}"));
            TempData["filePath"] = filePath;
            return (!Model.isMedicine(filePath)) ?
                RedirectToAction("NotMedicine") :
                RedirectToAction("Finish");

        }
        
        public ActionResult NotMedicine()
        {
            MedicineImage img = new MedicineImage(string.Empty);
            return View(img);
        }
        
        [HttpPost]
        public ActionResult NotMedicine(FormCollection collection)
        {

            return Check(collection);
        }
        [HttpGet]
        public ActionResult Finish()
        {
            MedicineModel Model = new MedicineModel();
            var filePath = (string)TempData["filePath"];
            var medicine = (Medicine)TempData["medicine"];
            Model.EditImage(medicine, filePath);
            
            return RedirectToAction("Index", "MedicinesList");
        }

        // POST: Home/Create
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

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
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

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
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
