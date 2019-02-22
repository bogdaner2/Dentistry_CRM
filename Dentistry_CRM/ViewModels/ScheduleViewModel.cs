using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Dentistry_CRM.DAL;
using Dentistry_CRM.Models;
using Dentistry_CRM.MVVM;

namespace Dentistry_CRM.ViewModels
{
    public class ScheduleViewModel : BindableBase
    {
        private const int START_WORK_DAY = 9;
        private const int END_WORK_DAY = 21;
        private readonly UnitOfWork _unitOfWork;
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
            _unitOfWork = new UnitOfWork();
        }

        public async Task GetDayAppointments(DateTime date)
        {
                var appointments = await _unitOfWork.AppointmentRepository
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

        public async void RemoveAppointment(DateTime time)
        {
            await _unitOfWork.AppointmentRepository.DeleteAllAsync(x => x.Time == time);
        }

        private async Task<ObservableCollection<ScheduleItem>> MapAppointmentItems(IEnumerable<Appointment> appointments)
        {
            return new ObservableCollection<ScheduleItem>(
                await Task.WhenAll(
                appointments.Select(async x =>
                    {
                        var patient = await _unitOfWork.PatientRepository.GetAsync(x.PatientId);
                        var doctor = await _unitOfWork.DoctorsRepository.GetAllAsync(doc => doc.Chair == x.Chair);
                        var type = await _unitOfWork.TypesRepository.GetAsync(x.TypeId);

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
    }
}
