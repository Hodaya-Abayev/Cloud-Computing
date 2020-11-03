using MyProject.BL.BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MyProject.Models
{
    public class ChartsViewModel
    {
        private Charts chart;
       [DisplayName("Medicine Name:")]
        public string MedicineName
        {
            get { return chart.MyMedicine.ProprietaryName; }
            set { chart.MyMedicine.ProprietaryName = value; }
        }
        [DisplayName("From:")]
        public DateTime From
        {
            get { return chart.From; }
            set { chart.From = value; }
        }
        [DisplayName("To:")]
        public DateTime To
        {
            get { return chart.To; }
            set { chart.To = value; }
        }
        public string Months
        {
            get { return chart.Months; }
            set { chart.Months = value; }
        }
        public List<int> Counts
        {
            get { return chart.Counts; }
            set { chart.Counts = value; }
        }
        public List<DateTime> Dates
        {
            get { return chart.Dates; }
            set { chart.Dates = value; }
        }
        public ChartsViewModel()
        {

        }
        public ChartsViewModel(Charts c)
        {
            this.chart = c;
        }


    }
}