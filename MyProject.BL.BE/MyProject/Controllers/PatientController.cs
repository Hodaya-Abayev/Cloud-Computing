using MyProject.BL.BE;
using MyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProject.Controllers
{
    public class PatientController : Controller
    {
        // GET: Patient
        public ActionResult Index()
        {
            PatientModel Model = new PatientModel();
           
            SelectList TZ = new SelectList(Model.GetTZ());
            
            
            ViewBag.TZ = TZ;
            return View();
        }

        // GET: Patient/Details/5
        [HttpPost]
        
        public ActionResult Index(string TZ)
        {
            if (TZ == "")
                return Index();
            
            PatientModel Model = new PatientModel();
            Patient patient = new Patient();
            patient = Model.GetPatient(Convert.ToInt32(TZ));
            
            TempData["patient"] = patient;
            if (Request.Form["details"] != null)
                return RedirectToAction("Details");
            else
            {
                
                return RedirectToAction("Check", "Doctor");
            }
            
        }
        [HttpGet]
        public ActionResult Details()
        {
            var patient =(Patient)TempData["patient"];
            PatientModel Model = new PatientModel();
            List<MedicineTimes> medicines = new List<MedicineTimes>(Model.GetMedicines(patient));
            //Model.GetMedicinesByName(medicines);
            PatientDetailsViewModel viewModel = new PatientDetailsViewModel(patient, medicines);
            return View(viewModel);
        }


        // GET: Patient/Create
        [HttpGet]
        
        public ActionResult Create()
        {
            var patient = (Patient)TempData["patient"];
            var doctor = (Doctor)TempData["doctor"];
            Prescription r = new Prescription(patient,doctor);
            MedicineModel Model = new MedicineModel();
            SelectList MedicineNames = new SelectList(Model.GetNames());
            ViewBag.MedicineNames = MedicineNames;
            PrescriptionViewModel viewModel = new PrescriptionViewModel(patient, doctor);
            TempData["MedicineNames"] = MedicineNames;
            TempData["prescription"] = r;
            TempData["patient"] = patient;
            TempData["doctor"] = doctor;


            return View(viewModel);
        }

        // POST: Patient/Create
        
        
        [HttpPost]
        
        
        // GET: Patient/Edit/5
        public ActionResult Create(FormCollection collection)
        {
            string MedicineName = collection.Get("name");
            var patient = (Patient)TempData["patient"];
            var doctor = (Doctor)TempData["doctor"];
            
            DateTime start = DateTime.Parse( collection.Get("start"));
            DateTime end = DateTime.Parse(collection.Get("end"));
            var prescription = (Prescription)TempData["prescription"];
            var MedicinesNames = (SelectList)TempData["MedicineNames"];
            MedicineModel medicineModel = new MedicineModel();
            PrescriptionModel prescriptionModel = new PrescriptionModel();
            
            MedicineTimes medicine = new MedicineTimes(medicineModel.GetMedicine(MedicineName), start, end);
            List<MedicineTimes> medicines = new List<MedicineTimes>();
            
            
            prescriptionModel.AddMedicine(medicines, medicine);
            PrescriptionViewModel viewModel = new PrescriptionViewModel(patient, doctor, medicines);
            ViewBag.MedicineNames = MedicinesNames;
            TempData["viewModel"] = viewModel;
            TempData["prescription"] = prescription;
            TempData["doctor"] = doctor;
            TempData["medicines"] = medicines;
            return RedirectToAction("Edit");
            
        }

        // POST: Patient/Edit/5
        
        
        [HttpGet]
        public ActionResult Edit()
        {
            var MedicineNames = (SelectList)TempData["MedicineNames"];
            ViewBag.MedicineNames = MedicineNames;
            var viewModel = (PrescriptionViewModel)TempData["viewModel"];
            TempData["MedicineNames"] = MedicineNames;
            return View(viewModel);
            
        }
        //[HttpGet]
        [HttpPost]
        public ActionResult Edit(FormCollection collection)
        {
            var doctor = (Doctor)TempData["doctor"];
            var patient = (Patient)TempData["patient"];
            var medicines = (List<MedicineTimes>)TempData["medicines"];
            var prescription = (Prescription)TempData["prescription"];
            string MedicineName = collection.Get("name");
            DateTime start = new DateTime();
            DateTime end = new DateTime();
            if (!DateTime.TryParse(collection.Get("start"), out start) && !DateTime.TryParse(collection.Get("end"),out end) || MedicineName == "" && Request.Form["Add"] == null)
            {
                TempData["prescription"] = prescription;
                TempData["medicines"] = medicines;
                return RedirectToAction("Check", "Interactions");

            }

            var MedicinesNames = (SelectList)TempData["MedicineNames"];
            MedicineModel medicineModel = new MedicineModel();
            PrescriptionModel prescriptionModel = new PrescriptionModel();
            MedicineTimes medicine = new MedicineTimes(medicineModel.GetMedicine(MedicineName), start, end);
            //PrescriptionMedicine rm = new PrescriptionMedicine(patient.TZ,MedicineNames, start, end);
            prescriptionModel.AddMedicine(medicines, medicine);
            PrescriptionViewModel viewModel = new PrescriptionViewModel(patient, doctor, medicines);
            ViewBag.MedicineNames = MedicinesNames;
            TempData["viewModel"] = viewModel;
           
            return RedirectToAction("Edit");
            




        }
        
        

            // POST: Patient/Delete/5
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
