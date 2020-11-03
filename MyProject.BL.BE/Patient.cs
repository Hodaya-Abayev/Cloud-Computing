using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.BL.BE
{ 
    public enum Gender 
    {
        Male,
        Female
    }
    public class Patient
    {
        public int ID { get; set; }   
        public long TZ { get; set; }
        public string Name { get; set; }      
        public double Age { get; set; }        
        public string PhoneNumber { get; set; }        
        public Gender PatientGender { get; set; }       
        //public List<PrescriptionMedicine> Medicines { get; set; }

        public Patient()
        {

        }
        public Patient(Patient p)
        {
            ID = p.ID;
            TZ = p.TZ;
            Name = p.Name;
            Age = p.Age;
            PhoneNumber = p.PhoneNumber;
            PatientGender = p.PatientGender;
            //Medicines = new List<PrescriptionMedicine>(p.Medicines);
        }
    }
    
}

