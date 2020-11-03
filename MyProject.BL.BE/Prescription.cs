using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.BL.BE
{
    public class Prescription
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public long PatientTZ { get; set; }
        public string DoctorName { get; set; }
        public string MedicineName { get; set; }
        //3public List<PrescriptionMedicine> Medicines { get; set; }

        public Prescription(Patient p, Doctor d, PrescriptionMedicine m)
        {
            this.PatientTZ = p.TZ;
            this.DoctorName = d.Name;
            this.Date = DateTime.Now;
            this.MedicineName = m.Name;
            //Medicines = new List<PrescriptionMedicine>();
        }
        public Prescription(Patient p, Doctor d)
        {
            this.PatientTZ = p.TZ;
            this.DoctorName = d.Name;
            this.Date = DateTime.Now;
        }
        public Prescription()
        {
              
        }



    }
}
