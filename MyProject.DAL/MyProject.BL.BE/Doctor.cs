using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.BL.BE
{
    public class Doctor
    {
        public int ID { get; set; }
        
        public long TZ { get; set; }
        
        public string Name { get; set; }
        public string Speciallization { get; set; }
        
        public int LicenseNumber { get; set; }
        public Doctor()
        {

        }
        public Doctor(Doctor d)
        {
            ID = d.ID;
            TZ = d.TZ;
            Name = d.Name;
            Speciallization = d.Speciallization;
            LicenseNumber = d.LicenseNumber;
        }
        

    }
}
