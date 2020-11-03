using MyProject.BL.BE;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProject.Models
{
    public class PatientViewModel
    {
        public Patient patient;
        public List<PatientViewModel> list;
        
        public int ID
        {
            get { return patient.ID; }
            set { patient.ID = value; }
        }

        [Display(Name = "ID number")]
        public long TZ
        {
            get { return patient.TZ; }
            set { patient.TZ = value; }
        }
        [Display(Name = "Name")]
        public string Name
        {
            get { return patient.Name; }
            set { patient.Name = value; }
        }
        [Display(Name = "Age")]
        public double Age
        {
            get { return patient.Age; }
            set { patient.Age = value; }
        }
        [Display(Name = "Phone Number")]
        public string PhoneNumber
        {
            get { return patient.PhoneNumber; }
            set { patient.PhoneNumber = value; }
        }
        [Display(Name = "Gender")]
        public Gender PatientGender
        {
            get { return patient.PatientGender; }
            set { patient.PatientGender = value; }
        }
        
        
        public List<PatientViewModel> GetList()
        {
            return list;
        }
        public PatientViewModel(List<Patient> patients)
        {
            list = new List<PatientViewModel>();
            foreach (var item in patients)
            {
                PatientViewModel m = new PatientViewModel(item);
                list.Add(m);
            }
        }
        public PatientViewModel(Patient p)
        {
            this.patient = p;
            
        }



    }
}