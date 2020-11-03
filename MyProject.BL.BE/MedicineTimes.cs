using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.BL.BE
{
    public class MedicineTimes
    {
        public Medicine MyMedicine { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public MedicineTimes(Medicine medicine, DateTime start, DateTime end)
        {
            MyMedicine = medicine;
            StartTime = start;
            EndTime = end;
        }
    }
}
