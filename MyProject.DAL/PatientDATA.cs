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
    public class PatientDATA : DbContext
    {
        public PatientDATA() : base("PatientDATA") { }

        public DbSet<Patient> Patient { get; set; }
        public DbSet<PrescriptionMedicine> PrescriptionMedicine { get; set; } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
