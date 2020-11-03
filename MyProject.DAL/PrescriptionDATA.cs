using MyProject.BL.BE;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DAL
{

    public class PrescriptionDATA : DbContext
    {
        public PrescriptionDATA() : base("PrescriptionDATA") { }

        public DbSet<Prescription> Prescription { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}

   
