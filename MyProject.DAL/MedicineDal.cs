using MyProject.BL.BE;
using System.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Xml.Linq;
using System.Data.Entity;

namespace MyProject.DAL
{
    public class MedicineDal
    {
        
        public Medicine GetMedicineById(int id)
        {
            using (MedicineDATA ctx = new MedicineDATA())
            {
                var medicine = ctx.Medicine.Where(s => s.ID == id).FirstOrDefault();
                return medicine;
            }
        }

        public List<Medicine> GetList()
        {
            using (MedicineDATA ctx = new MedicineDATA())
            {

                return ctx.Medicine.ToList();
            }
        }
        public List<PrescriptionMedicine> GetPatientMedicines(Patient patient)
        {
            using (PatientDATA ctx = new PatientDATA())
            {

                List<PrescriptionMedicine> medicines = new List<PrescriptionMedicine>(
                ctx.PrescriptionMedicine.Where(medicine=>medicine.PatientTZ==patient.TZ));
                return medicines;
            }
            

        }
        public List<string> Getinteractions(List<MedicineTimes> medicines, Prescription prescription)
        {
            List<string> ndc = new List<string>();
            List<string> descriptions = new List<string>();
            //List<PrescriptionMedicine> medicines = new List<PrescriptionMedicine>();
            List<Medicine> OverlapMedicines = new List<Medicine>();
            //foreach (var item in medicines)
            //{
            //    medicines.Add(item);
            //}
            Patient patient = new Patient();
            PatientDal dal = new PatientDal();
            patient = dal.GetPatientByTZ(prescription.PatientTZ);
            List<MedicineTimes> medicineTimes = new List<MedicineTimes>(medicines);
            foreach (var item in GetPatientMedicines(patient))
            {
                MedicineTimes medicine=new MedicineTimes(GetMedicineByName(item.Name), item.StartTime, item.EndTime);
                medicineTimes.Add(medicine);
            }
            
            foreach (var item1 in medicines)
            {
                bool overlapping = false;
                foreach (var item2 in medicines)
                {
                    if(item1!=item2&&item1.StartTime<=item2.EndTime&&item1.EndTime>=item2.StartTime)
                    {
                        overlapping = true;
                        Medicine medicine = new Medicine(GetMedicineByName(item2.MyMedicine.ProprietaryName));
                        OverlapMedicines.Add(medicine);
                    }
                }
                if (overlapping)
                {
                    Medicine medicine = new Medicine(GetMedicineByName(item1.MyMedicine.ProprietaryName));
                    OverlapMedicines.Add(medicine);
                }
            }
    
            foreach (var item in OverlapMedicines)
            {


                var httpRequest = (HttpWebRequest)WebRequest.Create("https://rxnav.nlm.nih.gov/REST/rxcui?idtype=NDC&id=" + item.NDC);

                //geting the response from the request url
                var response = (HttpWebResponse)httpRequest.GetResponse();

                //create a stream to hold the contents of the response (in this case it is the contents of the XML file
                var receiveStream = response.GetResponseStream();

                //creating XML document
                var mySourceDoc = new XmlDocument();

                //load the file from the stream
                mySourceDoc.Load(receiveStream);

                //close the stream
                receiveStream.Close();
                XmlNodeList elemList = mySourceDoc.GetElementsByTagName("rxnormId");
                ndc.Add(elemList[0].InnerText);
            }

            string url = "https://rxnav.nlm.nih.gov/REST/interaction/list?rxcuis=";
            foreach (var item in ndc)
            {
                url +=(item+"+");
            }
            url=url.Substring(0, url.Length - 1);
            var HttpRequest = (HttpWebRequest)WebRequest.Create(url);
            var Response = (HttpWebResponse)HttpRequest.GetResponse();
            var ReceiveStream = Response.GetResponseStream();
            var MySourceDoc = new XmlDocument();
            MySourceDoc.Load(ReceiveStream);
            ReceiveStream.Close();
            XmlNodeList ElemList = MySourceDoc.GetElementsByTagName("description");
            for (int i = 0; i < ElemList.Count; i++)
            {
                descriptions.Add(ElemList[i].InnerText);
            }
            List<string> interactions=descriptions.Distinct().ToList();
            return interactions;
            

        }
        public List<string> GetNames()
        {
            List<string> MedicinesNames = new List<string>();
            using (var ctx = new MedicineDATA())
            {
                foreach (var item in ctx.Medicine)
                {
                    MedicinesNames.Add(item.ProprietaryName);
                }
            }
            return MedicinesNames;
        }
        public Medicine GetMedicineByName(string name)
        {
            
                var medicine = GetList().Where(s => s.ProprietaryName == name||s.ProprietaryName==name+"\r\n").FirstOrDefault();
                return medicine;
            
        }
        public void EditImage(Medicine medicine, string path)
        {
            path=path.Remove(0, 39);
            path=path.Replace('\\', '/');
            using (var ctx = new MedicineDATA())
            {
                
                var m = ctx.Medicine.FirstOrDefault(x => x.ID == medicine.ID);
                ctx.Medicine.Remove(m);
                medicine.ImageURL = path;
                ctx.Medicine.Add(medicine);
                ctx.SaveChanges();
            }
            
        }
        public void Delete(int id)
        {
            using (MedicineDATA ctx = new MedicineDATA())
            {
                var medicine = ctx.Medicine.Where(s => s.ID == id).FirstOrDefault();
                ctx.Medicine.Remove(medicine);
                ctx.SaveChanges();
            }
        }
        public void Add(Medicine Medicine)
        {
            using (var ctx = new MedicineDATA())
            {
                ctx.Medicine.Add(Medicine);
                ctx.SaveChanges();
            }
        }

    }
}
