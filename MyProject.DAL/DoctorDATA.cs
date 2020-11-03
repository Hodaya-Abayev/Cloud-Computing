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

        public class DoctorDATA : DbContext
        {
            public DoctorDATA() : base("DoctorDATA") { }

            public DbSet<Doctor> Doctors { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                //Database.SetInitializer<DoctorDATA>(new DropCreateDatabaseIfModelChanges<DoctorDATA>());
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            }
        }
    
}
