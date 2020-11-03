using MyProject.BL.BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProject.Models
{
    public class AdministratorViewModel
    {
        private Administrator administrator;

        [DisplayName("User Name:")]
        
        public string Name
        {
            get { return administrator.Name; }
            set { administrator.Name = value; }
        }
        [DisplayName("Password:")]
        
        public long TZ
        {
            get { return administrator.TZ; }
            set { administrator.TZ = value; }
        }
       



    }
}