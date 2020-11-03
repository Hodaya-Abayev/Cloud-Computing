using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.BL.BE
{
    public class Administrator
    {
        
        public int ID { get; set; }
       
        public string Name { get; set; }
        
        public long TZ { get; set; }

        public Administrator()
        {
            Name = "Hodaya";
            TZ = 2020;
          
        }
    }
}
