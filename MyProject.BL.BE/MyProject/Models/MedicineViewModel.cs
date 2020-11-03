using MyProject.BL.BE;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProject.Models
{
    public class MedicineViewModel
    {
        private Medicine medicine;
        private List<MedicineViewModel> list;
        public int ID
        {
            get { return medicine.ID; }
            set { medicine.ID = value; }
        }
        [Display(Name = "NDC")]
        public string NDC
        {
            get { return medicine.NDC; }
            set { medicine.NDC = value; }
        }
        
        [Display(Name = "Proprietary name")]
        public string ProprietaryName
        {
            get { return medicine.ProprietaryName; }
            set { medicine.ProprietaryName = value; }
        }
        [Display(Name = "Generic name")]
        public string NonProprietaryName
        {
            get { return medicine.NonProprietaryName; }
            set { medicine.NonProprietaryName = value; }
        }
        [Display(Name = "Dosage form")]
        public string DosageForm
        {
            get { return medicine.DosageForm; }
            set { medicine.DosageForm = value; }
        }
        [Display(Name = "Active ingredient unit")]
        public string ActiveIngredUnit
        {
            get { return medicine.ActiveIngredUnit; }
            set { medicine.ActiveIngredUnit = value; }
        }
        [Display(Name = "Image")]
        public string ImageURL
        {
            get { return medicine.ImageURL; }
            set { medicine.ImageURL = value; }
        }

        
        public List<MedicineViewModel> GetList()
        {
            return list;
        }
        public MedicineViewModel(List<Medicine> medicines)
        {
            list = new List<MedicineViewModel>();
            foreach (var item in medicines)
            {
                MedicineViewModel m = new MedicineViewModel(item);
                list.Add(m);
            }
        }
        
        public MedicineViewModel(Medicine m)
        {
            this.medicine = m;
        }
        public MedicineViewModel()
        {
            
        }

    }
}