using MyProject.BL.BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MyProject.Models
{
    public class PrescriptionMedicineViewModel
    {

        public MedicineTimes prescriptionMedicine;
        
        private List<PrescriptionMedicineViewModel> list;
        public Medicine Medicine
        {
            get { return prescriptionMedicine.MyMedicine; }
            set { prescriptionMedicine.MyMedicine = value; }
        }
        //public string Name
        //{
        //    get { return prescriptionMedicine.Name; }
        //    set { prescriptionMedicine.Name = value; }
        //}
        [DisplayName("Start time:")]
        public DateTime StartTime
        {
            get { return prescriptionMedicine.StartTime; }
            set { prescriptionMedicine.StartTime = value; }
        }
        [DisplayName("End time:")]
        public DateTime EndTime
        {
            get { return prescriptionMedicine.EndTime; }
            set { prescriptionMedicine.EndTime = value; }
        }
        public PrescriptionMedicineViewModel(MedicineTimes rm)
        {
            this.prescriptionMedicine = rm;
        }
        public List<PrescriptionMedicineViewModel> GetList()
        {
            return list;
        }
        public PrescriptionMedicineViewModel(List<MedicineTimes> prescriptionMedicines)
        {
            list = new List<PrescriptionMedicineViewModel>();
            foreach (var item in prescriptionMedicines)
            {
                PrescriptionMedicineViewModel p = new PrescriptionMedicineViewModel(item);
                list.Add(p);
            }
        }




    }
}