using Dentistry_CRM.Models;

namespace Dentistry_CRM.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork()
        {
            var context = new MongoDataContext();
            DoctorsRepository = new MongoRepository<Doctor>(context);
            PatientRepository = new MongoRepository<Patient>(context);
            TypesRepository = new MongoRepository<TypeOfAppointment>(context);
            AppointmentRepository = new MongoRepository<Appointment>(context);
            ServiceRepository = new MongoRepository<Service>(context);
            UserRepository = new MongoRepository<User>(context);
        }
        public MongoRepository<Doctor> DoctorsRepository { get; private set; }
        public MongoRepository<Patient> PatientRepository { get; private set; }
        public MongoRepository<TypeOfAppointment> TypesRepository { get; private set; }
        public MongoRepository<Appointment> AppointmentRepository { get; private set; }
        public MongoRepository<User> UserRepository { get; private set; }
        public MongoRepository<Service> ServiceRepository { get; private set; }
    }
}
