using MyProject.BL.BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MyProject.Models
{
    public class DoctorViewModel
    {
        private Doctor doctor;
        private List<DoctorViewModel> list;
        public int ID
        {
            get { return doctor.ID; }
            set { doctor.ID = value; }
        }
        [DisplayName("Name")]

        public string Name
        {
            get { return doctor.Name; }
            set { doctor.Name = value; }
        }
        [DisplayName("ID Number")]
        public long TZ
        {
            get { return doctor.TZ; }
            set { doctor.TZ = value; }
        }
        [DisplayName("License Number")]
        public int LicenseNumber
        {
            get { return doctor.LicenseNumber; }
            set { doctor.LicenseNumber = value; }
        }
        [DisplayName("Speciallization")]
        public string Speciallization 
        {
            get { return doctor.Speciallization; }
            set { doctor.Speciallization = value; } 
        }
        public List<DoctorViewModel> GetList()
        {
            return list;
        }
        public DoctorViewModel(List<Doctor> doctors)
        {
            list = new List<DoctorViewModel>();
            foreach (var item in doctors)
            {
                DoctorViewModel m = new DoctorViewModel(item);
                list.Add(m);
            }
        }
        public DoctorViewModel(Doctor d)
        {
            this.doctor = d;
             
        }


    }
}