using MyProject.BL.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;

namespace MyProject.DAL
{
    public class ChartsDAL
    {
        public string GetJSMonth(List<string> month)
        {
            
            string jsMonths = JsonConvert.SerializeObject(month);
            return jsMonths;

        }
        public List<int> GetCount(Charts chart)
        {
     
            List<int> count = new List<int>();

            foreach (var date in chart.Dates)
         
            {
                List<Prescription> CurrentPrescriptions = new List<Prescription>(from prescription in GetList()
                                                               where prescription.Date.Month == date.Month
                                                               && prescription.Date.Year == date.Year
                                                               select prescription);
                List<string> medicines = new List<string>();
                
                    foreach (var item in CurrentPrescriptions)
                    {
                        
                        medicines.Add(item.MedicineName);
                    }
                

                count.Add((from medicine in medicines
                           where medicine == chart.MyMedicine.ProprietaryName+"\r\n"
                           select medicine).Count());
            }
            return count;

        }
        public List<Prescription> GetList()
        {
            PrescriptionDal dal = new PrescriptionDal();
            return dal.GetList();
        }
    }
}
