using System;
using System.Collections.Generic;
using System.Globalization;
using Dentistry_CRM.Models;

namespace Dentistry_CRM.DAL
{
    public class Seed
    {
        private static MongoRepository<Patient> _patientRepository;
        private static MongoRepository<Doctor> _doctorRepository;
        private static MongoRepository<TypeOfAppointment> _typeRepository;
        private static MongoRepository<Appointment> _appointmentRepository;
        private static MongoRepository<Service> _serviceRepository;

        static Seed()
        {
            IMongoDataContext context = new MongoDataContext();
            _patientRepository = new MongoRepository<Patient>(context);
            _doctorRepository = new MongoRepository<Doctor>(context);
            _typeRepository = new MongoRepository<TypeOfAppointment>(context);
            _appointmentRepository = new MongoRepository<Appointment>(context);
            _serviceRepository = new MongoRepository<Service>(context);
        }

        public static async void SeedData()
        {
            List<Patient> patients = new List<Patient>
            {
                new Patient { Fullname = "Петро Федорович" , Debt = 0 , Phone = "+380950000098"},
                new Patient { Fullname = "Олександр Федорович", Debt = 100, Phone = "+380950000100" },
                new Patient { Fullname = "Микита Федорович", Debt = -50, Phone = "+380950000111" },
                new Patient { Fullname = "Олег Федорович", Debt = 700, Phone = "+380950000000" }
            };

            List<Doctor> doctors = new List<Doctor>
            {
                new Doctor { Fullname = "Петро Федорович",Chair = 1, Phone = "+380950000098" },
                new Doctor { Fullname = "Петро Федорович",Chair = 1,Phone = "+380950000098" },
                new Doctor { Fullname = "Петро Федорович", Chair = 2,Phone = "+380950000098" }
            };

            List<TypeOfAppointment> typeOfAppointments = new List<TypeOfAppointment>
            {
                new TypeOfAppointment { Type = "Ортодонтология" , Color = "#61bd4f"},
                new TypeOfAppointment { Type = "Хирургия", Color = "#eb5a46" },
                new TypeOfAppointment { Type = "Терапия", Color = "#0079bf" },
                new TypeOfAppointment { Type = "Огляд", Color = "DarkGoldenrod" }
            };

            List<Appointment> appointments = new List<Appointment>
            {
                new Appointment {PatientId = patients[0].Id ,Chair = 1,TypeId = typeOfAppointments[0].Id , Time = DateTime.ParseExact("08-18-2018 08:30", "MM-dd-yyyy HH:mm", CultureInfo.InvariantCulture)},
                new Appointment {PatientId = patients[0].Id , Chair = 1, TypeId = typeOfAppointments[1].Id , Time = DateTime.ParseExact("08-18-2018 10:00", "MM-dd-yyyy HH:mm", CultureInfo.InvariantCulture) },
                new Appointment {PatientId = patients[1].Id , Chair = 2, TypeId = typeOfAppointments[1].Id ,Time = DateTime.ParseExact("08-18-2018 11:30", "MM-dd-yyyy HH:mm", CultureInfo.InvariantCulture) },
                new Appointment {PatientId = patients[0].Id , Chair = 1, TypeId = typeOfAppointments[1].Id , Time = DateTime.ParseExact("09-18-2018 08:00", "MM-dd-yyyy HH:mm", CultureInfo.InvariantCulture)},
                new Appointment {PatientId = patients[1].Id , Chair = 2, TypeId = typeOfAppointments[2].Id , Time = DateTime.ParseExact("09-18-2018 10:00", "MM-dd-yyyy HH:mm", CultureInfo.InvariantCulture) },
                new Appointment {PatientId = patients[2].Id , Chair = 1, TypeId = typeOfAppointments[0].Id , Time = DateTime.ParseExact("09-18-2018 11:00", "MM-dd-yyyy HH:mm", CultureInfo.InvariantCulture)},
                new Appointment {PatientId = patients[3].Id , Chair = 1, TypeId = typeOfAppointments[2].Id , Time = DateTime.ParseExact("09-18-2018 16:00", "MM-dd-yyyy HH:mm", CultureInfo.InvariantCulture)},
                new Appointment {PatientId = patients[2].Id , Chair = 1 , TypeId = typeOfAppointments[0].Id , Time = DateTime.ParseExact("10-18-2018 10:00", "MM-dd-yyyy HH:mm", CultureInfo.InvariantCulture)},
                new Appointment {PatientId = patients[3].Id , Chair = 2,TypeId = typeOfAppointments[0].Id ,Time = DateTime.ParseExact("10-18-2018 11:30", "MM-dd-yyyy HH:mm", CultureInfo.InvariantCulture)}
            };

            List<Service> services = new List<Service>
            {
                new Service { Name = "Стерильный набор", Price = 150 },
                new Service { Name = "Легкий кариес", Price = 150 },
                new Service { Name = "Средний кариес", Price = 350 },
                new Service { Name = "Глубокий кариес", Price = 650 },
                new Service { Name = "Анестизия", Price = 150 },
                new Service { Name = "Марля", Price = 150 },
                new Service { Name = "Прибор осмотра", Price = 350 },
                new Service { Name = "Шприц", Price = 50 },
                new Service { Name = "Удаление зуба", Price = 1000 }
            };

            if (await _patientRepository.CountDocumentsAsync() == 0)
            {
                await _patientRepository.InsertManyAsync(patients);
            }

            if (await _doctorRepository.CountDocumentsAsync() == 0)
            {
                await _doctorRepository.InsertManyAsync(doctors);
            }

            if (await _typeRepository.CountDocumentsAsync() == 0)
            {
                await _typeRepository.InsertManyAsync(typeOfAppointments);
            }

            if (await _appointmentRepository.CountDocumentsAsync() == 0)
            {
                await _appointmentRepository.InsertManyAsync(appointments);     
            }

            if (await _serviceRepository.CountDocumentsAsync() == 0)
            {
                await _serviceRepository.InsertManyAsync(services);
            }

            patients = null;
            doctors = null;
            services = null;
            typeOfAppointments = null;
            appointments = null;

            _patientRepository = null;
            _doctorRepository = null;
            _typeRepository = null;
            _appointmentRepository = null;
            _serviceRepository = null;
        }
    }
}
