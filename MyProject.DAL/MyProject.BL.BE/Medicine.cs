using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.BL.BE
{
    public class Medicine
    {
        public int ID { get; set; }
        public string NDC { get; set; }
        
        public string ProprietaryName { get; set; }
        
        public string NonProprietaryName { get; set; }
        
        public string DosageForm { get; set; }
        
        public string ActiveIngredUnit { get; set; }
        public string ImageURL { get; set; }
        public Medicine()
        {

        }
        public Medicine(Medicine m)
        {
            ID = m.ID;
            NDC = m.NDC;
            ProprietaryName = m.ProprietaryName;
            NonProprietaryName = m.NonProprietaryName;
            DosageForm = m.DosageForm;
            ActiveIngredUnit = m.ActiveIngredUnit;
            ImageURL = m.ImageURL;
        }
        


    }
   
}
