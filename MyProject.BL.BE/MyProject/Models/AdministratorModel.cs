using MyProject.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProject.Models
{
    public class AdministratorModel
    {
        AdministratorBL bl = new AdministratorBL();
        public bool Confirm(string name, long tz)
        {
           
            return bl.Confirm(name, tz);
        }
    }
}