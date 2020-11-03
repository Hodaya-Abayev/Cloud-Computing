using MyProject.BL.BE;
using MyProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.BL
{
    public class PrescriptionBL
    {
        PrescriptionDal dal = new PrescriptionDal();
        public void AddMedicine(List<MedicineTimes> medicines, MedicineTimes medicine)
        {
            medicines.Add(medicine);
        }
        public void AddPrescription(List<MedicineTimes> medicines, Prescription prescription)
        {
            
            dal.Add(medicines, prescription);
        }
        public void AddListMedicines(List<MedicineTimes> medicines, Prescription prescription)
        {
            
            
            PatientDal patientDal = new PatientDal();
            patientDal.AddMedicines(medicines,prescription);
           
        }
    }
}
