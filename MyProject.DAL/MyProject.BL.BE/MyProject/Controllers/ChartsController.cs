using MyProject.BL.BE;
using MyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MyProject.Controllers
{
    public class ChartsController : Controller
    {
        // GET: Charts
        public ActionResult Create()
        {
            MedicineModel Model = new MedicineModel();
            SelectList MedicineNames = new SelectList(Model.GetNames());
            ViewBag.MedicineNames = MedicineNames;
            ChartsViewModel viewModel = new ChartsViewModel();
            return View(viewModel);
            
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, Charts chart)
        {
            string MedicineName = collection.Get("name");
            
            chart.From = new DateTime(chart.From.Year, chart.From.Month, 1);
                chart.To = new DateTime(chart.To.Year, chart.To.Month, 1);
                Charts current = new Charts(MedicineName, chart.From, chart.To);

                ChartsModel model = new ChartsModel();
                model.GetChart(current);
                ChartsViewModel viewModel = new ChartsViewModel(current);
                TempData["viewModel"] = viewModel;
                return RedirectToAction("Index");
           
        }
        [HttpGet]
        public ActionResult Index()
        {
            var viewModel = (ChartsViewModel)TempData["viewModel"];
            return View(viewModel);
        }

            // GET: Charts/Details/5
            public ActionResult Details(int id)
        {
            return View();
        }

        

        // POST: Charts/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Charts/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Charts/Edit/5
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

        // GET: Charts/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Charts/Delete/5
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
