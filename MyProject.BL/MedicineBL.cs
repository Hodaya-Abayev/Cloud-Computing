using MyProject.BL.BE;
using MyProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.BL
{
    public class MedicineBL
    {
        MedicineDal dal = new MedicineDal();
        public List<string> CheckInteractions(List<MedicineTimes> medicines, Prescription prescription)
        {
            
            List<string> ndc=new List<string>(dal.Getinteractions(medicines, prescription));
            return ndc;

        }
        public List<string> GetNames()
        {
            
            return dal.GetNames();
        }
        public Medicine GetMedicine(string name)
        {
           
            return dal.GetMedicineByName(name);
        }
        public List<Medicine> GetList()
        {
            
            return dal.GetList();
        }
        public void EditImage(Medicine medicine, string path)
        {
           
            dal.EditImage(medicine, path);
        
        }
        public void Delete(Medicine medicine)
        {
            
            dal.Delete(medicine.ID);
        }
        public void CreateNew(Medicine medicine)
        {
            
            dal.Add(medicine);
        }

        public Medicine GetMedicineById(int id)
        {
            return dal.GetMedicineById(id);
        }
    }
}
