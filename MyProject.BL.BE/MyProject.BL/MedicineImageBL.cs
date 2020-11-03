using MyProject.BL.BE;
using MyProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.BL
{
    public class MedicineImageBL
    {
        MedicineImageDal dal = new MedicineImageDal();
        public List<string> CheckImage(string URL)
        {
            List<string> Result = new List<string>();

            double Threshold = 50.0;
            MedicineImage Image = new MedicineImage(URL);
            Image.Description = new Dictionary<string, double>();
           
            dal.GetImageDescription(Image);
            foreach (var item in Image.Description)
            {
                if (item.Value >= Threshold)
                    Result.Add(item.Key);
                else
                    break;
            }
            return Result;
            
        }
        public bool IsMedicine(List<string> description)
        {
            return (description.Contains("medicine") ||
                description.Contains("drug") ||
                description.Contains("pill") ||
                description.Contains("powder") ||
                description.Contains("bottle") ||
                description.Contains("medical") ||
                description.Contains("pill bottle") ||
                description.Contains("syrup"));
        }
    }
}
