using MyProject.BL.BE;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DAL
{
    public class PatientDal
    {
        
        
        
           
        public List<MedicineTimes> GetMedicines(Patient patient)
        {
            
                var medicines = from m in GetMedicinesList()
                                where m.PatientTZ == patient.TZ
                                select m;
            List<MedicineTimes> medicineTimes = new List<MedicineTimes>();
            MedicineDal dal = new MedicineDal();
            
                foreach (var item in medicines)
                {
                    
                    medicineTimes.Add(new MedicineTimes(dal.GetMedicineByName(item.Name), item.StartTime, item.EndTime));
                }
                return medicineTimes;
            
            
            

                   
        }

        public void AddMedicines(List<MedicineTimes> medicines, Prescription prescription)
        {
            using (var ctx = new PatientDATA())
            {
                foreach (var item in medicines)
                {
                    PrescriptionMedicine medicine = new PrescriptionMedicine(prescription.PatientTZ, item.MyMedicine.ProprietaryName, item.StartTime, item.EndTime);
                    ctx.PrescriptionMedicine.Add(medicine);
                    ctx.SaveChanges();
                }
            }
        }

        public void Delete(int id)
        {
            using (var ctx = new PatientDATA())
            {
                var patient = ctx.Patient.Where(s => s.ID == id).FirstOrDefault();
                ctx.Patient.Remove(patient); // פונקציות של הדאטה בייס
                ctx.SaveChanges(); // שמירת שינויים
            }
        }

        public void Edit(Patient patient)
        {
            using (var ctx = new PatientDATA())
            {
                var p = ctx.Patient.FirstOrDefault(x => x.ID == patient.ID);
                ctx.Patient.Remove(p);
                ctx.Patient.Add(patient);
                ctx.SaveChanges();
            }
        }

        public void Add(Patient Patient)
        {
            using (var ctx = new PatientDATA())
            {
                ctx.Patient.Add(Patient);
                ctx.SaveChanges();
            }
        }

        public List<Patient> GetList()
        {
            using (var ctx = new PatientDATA())
            {
                return ctx.Patient.ToList();
            }
        
        }
        public List<PrescriptionMedicine> GetMedicinesList()
        {
            using (var ctx = new PatientDATA())
            {
                return ctx.PrescriptionMedicine.ToList();
            }

        }
        public Patient GetPatientByID(int id)
        {
            using (var ctx = new PatientDATA())
            {
                var Patient = ctx.Patient.Where(s => s.ID == id).FirstOrDefault();
                return Patient;
            }
        }
        public Patient GetPatientByTZ(long tz)
        {
            using (var ctx = new PatientDATA())
            {
                var Patient = ctx.Patient.Where(s => s.TZ == tz).FirstOrDefault();
                return Patient;
            }
        }
        public List<string> GetTZ()
        {
            using (var ctx = new PatientDATA())
            {
                List<string> TZ = new List<string>();
                foreach (var item in ctx.Patient)
                {
                    TZ.Add(item.TZ.ToString());
                }
                return TZ;
            }
        }
    }
}
