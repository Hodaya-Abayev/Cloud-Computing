using MyProject.BL.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProject.Models
{
    public class PatientDetailsViewModel
    {
        public PatientViewModel patient;
        public List<PrescriptionMedicineViewModel> list { get; set; }
        
        public Patient Patient
        {
            get { return patient.patient; }
            set { patient.patient = value; }
        }
        


        public PatientDetailsViewModel(Patient p, List<MedicineTimes> l)
        {
            patient = new PatientViewModel(p);
            list = new List<PrescriptionMedicineViewModel>();
            foreach (var item in l)
            {
                PrescriptionMedicineViewModel model = new PrescriptionMedicineViewModel(item);
                list.Add(model);
            }
        }

    }
}