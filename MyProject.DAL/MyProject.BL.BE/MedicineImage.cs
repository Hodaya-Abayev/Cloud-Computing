using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.BL.BE
{
    public class MedicineImage
    {
        public int ID { get; set; }
        public string ImageUrl { get; set; }
        public Dictionary<string, double> Description { get; set; }//Key is detected image content, value is propability 
        public MedicineImage(string URL)
        {
            this.ImageUrl = URL;
        }
    }
}
