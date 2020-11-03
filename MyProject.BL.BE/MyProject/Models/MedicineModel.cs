using MyProject.BL;
using MyProject.BL.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProject.Models
{
    public class MedicineModel
    {
        MedicineBL bl = new MedicineBL();
        public List<string> Interactions(List<MedicineTimes> medicines, Prescription prescription)
        {
            
            return bl.CheckInteractions(medicines,prescription);
        }
        public List<string> GetNames()
        {
            
            return bl.GetNames();
        }
        public Medicine GetMedicine(string name)
        {
            
            return bl.GetMedicine(name);
        }
        public List<Medicine> GetList()
        {
            
            return bl.GetList();
        }
        public void EditImage(Medicine medicine, string path)
        {
            
            bl.EditImage(medicine, path);
        
        }
        public void Delete(Medicine medicine)
        {
            
            bl.Delete(medicine);

        }
        public void CreateNew(Medicine medicine)
        {
            
            bl.CreateNew(medicine);
        }

        internal Medicine GetMedicineById(int id)
        {
            return bl.GetMedicineById(id);
        }
    }
}