using MyProject.BL.BE;
using MyProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.BL
{
    public class PatientBL
    {
        PatientDal dal = new PatientDal();

        public Patient GetPatientByID(int id)
        {
            
            return dal.GetPatientByID(id);

        }
        public Patient GetPatientByTZ(long tz)
        {

            return dal.GetPatientByTZ(tz);

        }
        public List<string> GetTZ()
        {
           
            return dal.GetTZ();
        }
        public List<Patient> GetList()
        {
            
            return dal.GetList();
        }

        public void CreateNew(Patient patient)
        {
            dal.Add(patient);
        }

        public void Edit(Patient patient)
        {
            dal.Edit(patient);
        }

        public void Delete(Patient patient)
        {
            dal.Delete(patient.ID);
        }

        public List<MedicineTimes> GetMedicines(Patient patient)
        {
            return dal.GetMedicines(patient);
        }
    }
}
