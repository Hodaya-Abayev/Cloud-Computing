using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.BL.BE
{
    public class PrescriptionMedicine
    {
        public int ID { get; set; }
        public long PatientTZ { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public PrescriptionMedicine(long tz, string name, DateTime start, DateTime end)
        {
            PatientTZ = tz;
            Name = name;
            StartTime = start;
            EndTime = end;
        }
        public PrescriptionMedicine()
        {

        }
    }
}
