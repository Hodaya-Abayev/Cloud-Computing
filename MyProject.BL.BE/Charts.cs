using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.BL.BE
{
    
    public class Charts
    {
        public Medicine MyMedicine { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string Months { get; set; }
        public List<int> Counts { get; set; }
        public List<DateTime> Dates { get; set; }
        public Charts()
        {

        }
        public Charts(string name, DateTime from, DateTime to)
        {
            MyMedicine = new Medicine();
            MyMedicine.ProprietaryName = name;
            From = from;
            To = to;

        }

    }
}
