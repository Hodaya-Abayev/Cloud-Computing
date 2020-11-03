using MyProject.BL.BE;
using MyProject.DAL;
using MyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
                return View();
            
        }

        public ActionResult Admin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Admin(Administrator administrator)
        {
            AdministratorModel Model = new AdministratorModel();
            if (Model.Confirm(administrator.Name, administrator.TZ))
                return RedirectToAction("Index", "AdministratorLogin");
            return RedirectToAction("ErrorAdmin");

        }
        public ActionResult ErrorAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ErrorAdmin(Administrator administrator)
        {
            return Admin(administrator);
        }

        public ActionResult Doctor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Doctor(Doctor doctor)
        {
            DoctorModel Model = new DoctorModel();
            Doctor d = new Doctor();
            d = Model.Confirm(doctor.LicenseNumber, doctor.TZ);
            if (d != null)
            {
                TempData["doctor"] = d;
                return RedirectToAction("Index", "Patient");
            }
            return RedirectToAction("ErrorDoctor");

        }
        public ActionResult ErrorDoctor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ErrorDoctor(Doctor doctor)
        {
            return Doctor(doctor);
        }
    }
}
