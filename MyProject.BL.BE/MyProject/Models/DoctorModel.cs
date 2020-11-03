using MyProject.BL;
using MyProject.BL.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProject.Models
{
    public class DoctorModel
    {
        DoctorBL bl = new DoctorBL();
        public Doctor Confirm(int licenseNumber, long tz)
        {
           
            return bl.Confirm(licenseNumber, tz);
        }
        public bool isLicense(string Name)
        {
            
            return bl.CheckLicense(Name);

        }
        public List<Doctor> GetList()
        {
            
            return bl.GetList();
        }
        public Doctor GetDoctor(int id)
        {

            return bl.GetDoctor(id);
        }

        public void Edit(Doctor doctor)
        {
            bl.Edit(doctor);
        }

        public void Delete(Doctor doctor)
        {
            bl.Delete(doctor);
        }

        public void CreateNew(Doctor doctor)
        {
            bl.CreateNew(doctor);
        }
    }
}