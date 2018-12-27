using Dentistry_CRM.Models;

namespace Dentistry_CRM.DAL
{
    public interface IUnitOfWork
    {
        MongoRepository<Doctor> DoctorsRepository { get;  }
        MongoRepository<Patient> PatientRepository { get;  }
        MongoRepository<TypeOfAppointment> TypesRepository { get; }
        MongoRepository<Appointment> AppointmentRepository { get;  }
        MongoRepository<Service> ServiceRepository { get; }
        MongoRepository<User> UserRepository { get; }
    }
}
