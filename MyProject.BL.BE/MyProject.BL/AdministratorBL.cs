using MyProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.BL
{
    public class AdministratorBL
    {
        public bool Confirm(string name, long tz)
        {
            AdministratorDal dal = new AdministratorDal();
            return dal.Confirm(name, tz);
        }
    }
}
