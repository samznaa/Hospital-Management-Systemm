using Hospital.dll.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.dll.Context
{


    public class HospitalDBContext : DbContext
    {
        //public DbSet<Hospitall> Hospitals { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
        //public DbSet<Appointment> Appointment { get; set; }
        public DbSet<Department> Department { get; set; }



        //public DbSet<Doctor> Doctor { get; set; }
        //public DbSet<Bill> Bills { get; set; }

        //public DbSet<Lab> Labs { get; set; }
        //public DbSet<Medicine> Medicines { get; set; }
        //public DbSet<MedicineReport> MedicineReports { get; set; }
        //public DbSet<PatientReport> PatientReports { get; set; }

        //public DbSet<Payroll> Payrolls { get; set; }
        //public DbSet<Room> Room { get; set; }
        //public DbSet<Supplier> Suppliers { get; set; }
        //public DbSet<PrescribedMedicine> PrescribedMedicines { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)

        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }


    }
}
