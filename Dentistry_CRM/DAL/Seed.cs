using System;
using System.Collections.Generic;
using System.Globalization;
using Dentistry_CRM.Models;

namespace Dentistry_CRM.DAL
{
    public class Seed
    {
        private static UnitOfWork uow;


        static Seed()
        {
            uow = new UnitOfWork();
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

            List<User> users = new List<User>
            {
                new User { Login = "admin" , Password = "admin" , Role = Role.Admin},
                new User { Login = "doctor" , Password = "doctor" , Role = Role.Doctor}
            };

            if (await uow.PatientRepository.CountDocumentsAsync() == 0)
            {
                await uow.PatientRepository.InsertManyAsync(patients);
            }

            if (await uow.DoctorsRepository.CountDocumentsAsync() == 0)
            {
                await uow.DoctorsRepository.InsertManyAsync(doctors);
            }

            if (await uow.TypesRepository.CountDocumentsAsync() == 0)
            {
                await uow.TypesRepository.InsertManyAsync(typeOfAppointments);
            }

            if (await uow.AppointmentRepository.CountDocumentsAsync() == 0)
            {
                await uow.AppointmentRepository.InsertManyAsync(appointments);     
            }

            if (await uow.ServiceRepository.CountDocumentsAsync() == 0)
            {
                await uow.ServiceRepository.InsertManyAsync(services);
            }

            if (await uow.UserRepository.CountDocumentsAsync() == 0)
            {
                await uow.UserRepository.InsertManyAsync(users);
            }

            patients = null;
            doctors = null;
            services = null;
            typeOfAppointments = null;
            appointments = null;

            uow = null;
        }
    }
}
