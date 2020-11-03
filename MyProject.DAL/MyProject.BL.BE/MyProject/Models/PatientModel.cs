using MyProject.BL;
using MyProject.BL.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProject.Models
{
    public class PatientModel
    {
        PatientBL bl = new PatientBL();
        public Patient GetPatient(long id)
        {
            
            return bl.GetPatientDetails( id);
        }
        public List<string> GetTZ()
        {
            
            return bl.GetTZ();
        }
        public List<Patient> GetList()
        {
            
            return bl.GetList();
        }

        public void CreateNew(Patient patient)
        {
            bl.CreateNew(patient);
        }

        public void Edit(Patient patient)
        {
            bl.Edit(patient);
        }

        public void Delete(Patient patient)
        {
            bl.Delete(patient);
        }

        public List<MedicineTimes> GetMedicines(Patient patient)
        {
            return bl.GetMedicines(patient);
        }
    }
}