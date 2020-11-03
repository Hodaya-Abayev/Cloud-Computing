using MyProject.BL.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DAL
{
    public class AdministratorDal
    {
        public bool Confirm(string name, long tz)
        {
            Administrator administrator = new Administrator();
            if (administrator.Name == name && administrator.TZ == tz)
                return true;
            return false;
        }
    }
}
