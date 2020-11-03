using Grpc.Core;
using MyProject.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

namespace MyProject.Models
{
    public class MedicineImageModel
    {
        public int ID { get; set; }
        public string ImageURL { get; set; }
        public List<string> Description { get; set; }
        MedicineImageBL bl = new MedicineImageBL();

        public bool isMedicine(string filePath)
        {

            
            this.Description= new List<string>(bl.CheckImage(filePath));
            return bl.IsMedicine(this.Description);

        }
    }
    
    
}