using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Dentistry_CRM.DAL;
using Dentistry_CRM.Models;
using Dentistry_CRM.MVVM;
using MahApps.Metro.Controls.Dialogs;

namespace Dentistry_CRM.ViewModels
{
    public class ScheduleViewModel : BaseViewModel
    {
        private const int START_WORK_DAY = 9;
        private const int END_WORK_DAY = 21;
        private readonly MongoRepository<Patient> _patientRepository;
        private readonly MongoRepository<Doctor> _doctorRepository;
        private readonly MongoRepository<TypeOfAppointment> _typeRepository;
        private readonly MongoRepository<Appointment> _appointmentRepository;
        private ObservableCollection<ScheduleItem> _firstChair;
        private ObservableCollection<ScheduleItem> _secondChair;


        public ObservableCollection<ScheduleItem> FirstChair
        {
            get => _firstChair;
            set => SetProperty(ref _firstChair, value);
        }
        public ObservableCollection<ScheduleItem> SecondChair
        {
            get => _secondChair;
            set => SetProperty(ref _secondChair, value);
        }


        public ScheduleViewModel()
        {
            IMongoDataContext context = new MongoDataContext();
            _patientRepository = new MongoRepository<Patient>(context);
            _doctorRepository = new MongoRepository<Doctor>(context);
            _typeRepository = new MongoRepository<TypeOfAppointment>(context);
            _appointmentRepository = new MongoRepository<Appointment>(context);
        }

        public async Task GetDayAppointments(DateTime date)
        {
            try
            {
                var appointments = await _appointmentRepository
                    .GetAllAsync(x => x.Time > date && date.AddDays(1) > x.Time);

                var firstChair = appointments.Where(x => x.Chair == 1);
                var secondChair = appointments.Where(x => x.Chair == 2);

                FirstChair = await MapAppointmentItems(firstChair);
                SecondChair = await MapAppointmentItems(secondChair);

                if(FirstChair != null)
                    FirstChair = SetFreeSpots(FirstChair, date);

                if (SecondChair != null)
                    SecondChair = SetFreeSpots(SecondChair, date);

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Free times fills by empty appointments/Should Refactor
        /// </summary>
        /// <returns></returns>
        private ObservableCollection<ScheduleItem> SetFreeSpots(ObservableCollection<ScheduleItem> items,DateTime date)
        {
            var startTime = date.AddHours(9);
            var counter = END_WORK_DAY - START_WORK_DAY;
            var times = items.Select(x => x.Time);
            var copy = new ObservableCollection<ScheduleItem>(items);
            while (counter != 0)
            {
                if(!times.Contains(startTime))
                    copy.Add(new ScheduleItem { Time = startTime , Color = "gray"});

                startTime = startTime.AddHours(1);
                counter--;
            }

            return new ObservableCollection<ScheduleItem>(copy.OrderBy(x => x.Time));
        }

        private async Task<ObservableCollection<ScheduleItem>> MapAppointmentItems(IEnumerable<Appointment> appointments)
        {
            return new ObservableCollection<ScheduleItem>(
                await Task.WhenAll(
                appointments.Select(async x =>
                    {
                        var patient = await _patientRepository.GetAsync(x.PatientId);
                        var doctor = await _doctorRepository.GetAllAsync(doc => doc.Chair == x.Chair);
                        var type = await _typeRepository.GetAsync(x.TypeId);

                        return new ScheduleItem
                        {
                            PatientName = patient.Fullname,
                            Phone = patient.Phone,
                            Debt = patient.Debt.ToString(),
                            Time = x.Time,
                            DoctorName = doctor.FirstOrDefault()?.Fullname,
                            Color = type.Color

                        };
                    }))
            );
        }

        public async Task AddAppointment(Appointment appointment)
        {
           
        }
    }
}
