using MyProject.BL;
using MyProject.BL.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;




namespace MyProject.Models
{
    public class ChartsModel
    {
        ChartsBL bl = new ChartsBL();
        public void GetChart( Charts chart)
        {
            
            
            var Period=(bl.GetMonth(chart.From, chart.To));
            chart.Months= Period.Item2;
            chart.Dates = new List<DateTime>(Period.Item1);
            chart.Counts = bl.GetCount( chart);
        }
    }
}