using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Dentistry_CRM.Models;


namespace Dentistry_CRM.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? selectedDate = Calendar.SelectedDate;

            MessageBox.Show(selectedDate.Value.Date.ToShortDateString());
            try
            {
                using (var db = new DentistryContext())
                {
                    await db.Patients.LoadAsync();
                    db.Patients.Add(new Patient
                    {
                        Id = Guid.NewGuid(),
                        Dubt = "200",
                        Fullname = "Bohdan",
                        Phone = "0555555555"
                    });
                    
                    await db.SaveChangesAsync();
                    MessageBox.Show(db.Patients.Count().ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //string connectionString = "server=localhost;port=3306;database=dentistry;uid=root;password=KonorinDev22";
            //        // DbConnection that is already opened
            //        using (DentistryContext context = new DentistryContext())
            //        {


            //            context.Patients.Add(new Patient
            //            {
            //                Dubt = "200",
            //                Fullname = "Bohdan",
            //                Phone = "0555555555"
            //            });

            //            await context.SaveChangesAsync();
            //        }
            //}
        }
    }
}
