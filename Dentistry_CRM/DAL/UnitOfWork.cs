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
        }
        public MongoRepository<Doctor> DoctorsRepository { get; private set; }
        public MongoRepository<Patient> PatientRepository { get; private set; }
        public MongoRepository<TypeOfAppointment> TypesRepository { get; private set; }
        public MongoRepository<Appointment> AppointmentRepository { get; private set; }
    }
}
