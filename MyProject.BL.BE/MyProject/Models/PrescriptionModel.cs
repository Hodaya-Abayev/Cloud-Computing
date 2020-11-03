using MyProject.BL;
using MyProject.BL.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProject.Models
{
    public class PrescriptionModel
    {
        PrescriptionBL bl = new PrescriptionBL();
        public void AddMedicine(List<MedicineTimes> medicine, MedicineTimes prescription)
        {
           
            bl.AddMedicine( medicine, prescription);
        
        }
       public void AddPrescription(List<MedicineTimes> medicines, Prescription prescription)
        {
            
            bl.AddPrescription(medicines,prescription);
        }
        public void AddListMedicines(List<MedicineTimes> medicines, Prescription prescription)
        {
            
            bl.AddListMedicines(medicines,prescription);
        }
    }
}