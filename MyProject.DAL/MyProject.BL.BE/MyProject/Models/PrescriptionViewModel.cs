using MyProject.BL.BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProject.Models
{
    public class PrescriptionViewModel
    {
        private Prescription prescription;
        [DisplayName("Date:")]
        public DateTime Date { get; set; }
        
        public PatientViewModel Patient { get; set; }

        public DoctorViewModel Doctor { get; set; }
        [DisplayName("Start time:")]
        [Required]
        public DateTime Start { get; set; }
        [DisplayName("End time:")]
        [Required]
        public DateTime End { get; set; }

        public List<PrescriptionMedicineViewModel> Medicines { get; set; }

        public PrescriptionViewModel(Patient p, Doctor d, List<MedicineTimes> m)
        {
            //this.prescription = r;
            Patient = new PatientViewModel(p);
            Doctor = new DoctorViewModel(d);
            Medicines = new List<PrescriptionMedicineViewModel>();
            foreach (var item in m)
            {
                PrescriptionMedicineViewModel pr = new PrescriptionMedicineViewModel(item);
                Medicines.Add(pr);
            }
            //foreach (var item in r.Medicines)
            //{
            //    PrescriptionMedicineViewModel medicine = new PrescriptionMedicineViewModel(item);
            //    Medicines.Add(medicine);
            //}
        }
        public PrescriptionViewModel(Patient p, Doctor d)
        {
            //this.prescription = r;
            Patient = new PatientViewModel(p);
            Doctor = new DoctorViewModel(d);
            Date = DateTime.Now;



        }
    }
}