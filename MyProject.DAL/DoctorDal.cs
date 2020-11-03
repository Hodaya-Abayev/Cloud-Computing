using System;
using MyProject.BL.BE;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Data.Entity;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MyProject.DAL
{
    public class DoctorDal
    {
        
        public List<Doctor> GetList()
        {
            using (var ctx = new DoctorDATA())
            {
                return ctx.Doctors.ToList();
            }
        }
        public Doctor Confirm(int licenseNumber, long tz)
        {
            using (var ctx = new DoctorDATA())
            {
                return ctx.Doctors.FirstOrDefault(x => x.TZ == tz && x.LicenseNumber == licenseNumber);
            }

        }

        public void Edit(Doctor doctor)
        {
            using (var ctx = new DoctorDATA())
            {
                var d = ctx.Doctors.FirstOrDefault(x => x.ID == doctor.ID);
                ctx.Doctors.Remove(d);
                ctx.Doctors.Add(doctor);
                ctx.SaveChanges();
            }

        }

        public void Add(Doctor doctor)
        {
            using (var ctx = new DoctorDATA())
            {
                ctx.Doctors.Add(doctor);
                ctx.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var ctx = new DoctorDATA())
            {
                var doctor = ctx.Doctors.Where(s => s.ID == id).FirstOrDefault();
                ctx.Doctors.Remove(doctor); // פונקציות של הדאטה בייס
                ctx.SaveChanges(); // שמירת שינויים
            }
        }

        public Doctor GetDoctorByID(int id)
        {
            using (var ctx = new DoctorDATA())
            {
                var doctor = ctx.Doctors.Where(s => s.ID == id).FirstOrDefault();
                return doctor;
            }
        }
        public bool CheckLicense(string Name)
        {
            IWebDriver driver = null;
            IWebElement temp = null;
            try
            {
                
                ChromeOptions options = new ChromeOptions();
                options.AddArguments("--incognito");

                driver = new ChromeDriver(@"C:\Users\הודיה\Downloads\chromedriver_win32 (1)");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                driver.Url = "https://practitioners.health.gov.il/Practitioners/1/search?name=" + Name;
                try
                {
                    temp = driver.FindElement(By.ClassName("statusdate-popover"));
                }
                catch
                {
                    return false;
                }

                // interact with driver to get data from the page.
            }
            finally
            {
                if (driver != null)
                    driver.Dispose();
            }

            if (temp != null)
                return true;
            return false;



        }

    }
}




