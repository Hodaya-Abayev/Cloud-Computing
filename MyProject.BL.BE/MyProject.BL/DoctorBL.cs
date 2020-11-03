using MyProject.BL.BE;
using MyProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.BL
{
    public class DoctorBL
    {
        DoctorDal dal = new DoctorDal();
        public Doctor Confirm(int licenseNumber, long tz)
        {
           
            return dal.Confirm(licenseNumber, tz);
        }
        public bool CheckLicense(string Name)
        {
      
            bool isLicense = dal.CheckLicense(Name);

            if (isLicense == true)
                return true;
            return false;
        }
        public List<Doctor> GetList()
        {
            
            return dal.GetList();
        }

        public Doctor GetDoctor(int id)
        {
            return dal.GetDoctorByID(id);
        }

        public void Edit(Doctor doctor)
        {
            dal.Edit(doctor);
        }

        public void Delete(Doctor doctor)
        {
            dal.Delete(doctor.ID);
        }

        public void CreateNew(Doctor doctor)
        {
            dal.Add(doctor);
        }
    }


}
