using MyProject.BL.BE;
using MyProject.DAL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.BL
{
    public class ChartsBL
    {
        ChartsDAL dal = new ChartsDAL();
        public (List<DateTime>, string) GetMonth(DateTime from, DateTime to)
        {
            DateTime date = new DateTime();
            List<DateTime> dates = new List<DateTime>();
            int NumOfMonth = ((to.Year - from.Year) * 12) + Math.Abs(to.Month - from.Month);
            List<string> month = new List<string>();
            
            for (int i = 0; i <= NumOfMonth; i++)
            {
                date =from.AddMonths(i);
                dates.Add(date);
                month.Add(date.Month.ToString()+'/'+date.Year.ToString());
            }
            
            string jsMonth=dal.GetJSMonth(month);
            return (dates, jsMonth);
        }
        public List<int> GetCount( Charts chart)
        {
            
            return dal.GetCount(chart);
        }

    }
}
