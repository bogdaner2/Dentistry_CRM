using System.Data.Common;
using System.Data.Entity;
using System.Windows;
using Dentistry_CRM.Models;

namespace Dentistry_CRM.Models
{
    public class DentistryContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }

        public DentistryContext() : base("DentistryContext")
        {
            Database.SetInitializer<DentistryContext>(new DropCreateDatabaseAlways<DentistryContext>());
            //MessageBox.Show(s);
        }
    }
}
