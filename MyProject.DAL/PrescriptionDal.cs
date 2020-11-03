using MyProject.BL.BE;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DAL
{
    public class PrescriptionDal
    {
        
        
        public void Add(List<MedicineTimes> medicines, Prescription prescription)
        {
            Doctor doctor = new Doctor(GetDoctor(prescription));
            Patient patient = new Patient(GetPatient(prescription));
            using (var ctx = new PrescriptionDATA())
            {
                foreach (var item in medicines)
                {
                    PrescriptionMedicine medicine = new PrescriptionMedicine(patient.TZ, item.MyMedicine.ProprietaryName, item.StartTime, item.EndTime);
                    Prescription p = new Prescription(patient, doctor, medicine);
                    ctx.Prescription.Add(p);
                    ctx.SaveChanges();
                }
                
            }
        }
        public Patient GetPatient(Prescription prescription)
        {
           
                PatientDal dal = new PatientDal();
                return dal.GetList().Find(x => x.TZ == prescription.PatientTZ);
            
          
        }
        public Doctor GetDoctor(Prescription prescription)
        {

            DoctorDal dal = new DoctorDal();
            return dal.GetList().Find(x => x.Name == prescription.DoctorName);


        }
        public List<Prescription> GetList()
        {
            using (var ctx = new PrescriptionDATA())
            {
                return ctx.Prescription.ToList();
            }
        }

    }
}
