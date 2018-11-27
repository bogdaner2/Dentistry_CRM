using Dentistry_CRM.Models;

namespace Dentistry_CRM.DAL
{
    public class Seed
    {
        private static MongoRepository<Patient> _patientRepository;
        private static MongoRepository<Doctor> _doctorRepository;
        private static MongoRepository<TypeOfAppointment> _typeRepository;
        private static MongoRepository<Appointment> _appointmentRepository;
        static Seed()
        {
            IMongoDataContext context = new MongoDataContext();
            _patientRepository = new MongoRepository<Patient>(context);
            _doctorRepository = new MongoRepository<Doctor>(context);
            _typeRepository = new MongoRepository<TypeOfAppointment>(context);
            _appointmentRepository = new MongoRepository<Appointment>(context);
        }

        public static async void SeedData()
        {
            if (_patientRepository.CountDocuments() == 0)
            {
                await _patientRepository.CreateAsync(new Patient { });
                await _patientRepository.CreateAsync(new Patient { });
                await _patientRepository.CreateAsync(new Patient { });
                await _patientRepository.CreateAsync(new Patient { });

            }

            if (_doctorRepository.CountDocuments() == 0)
            {
                await _doctorRepository.CreateAsync(new Doctor { });
                await _doctorRepository.CreateAsync(new Doctor { });
                await _doctorRepository.CreateAsync(new Doctor { });
                await _doctorRepository.CreateAsync(new Doctor { });
            }

            if (_typeRepository.CountDocuments() == 0)
            {
                await _typeRepository.CreateAsync(new TypeOfAppointment { });
                await _typeRepository.CreateAsync(new TypeOfAppointment { });
                await _typeRepository.CreateAsync(new TypeOfAppointment { });
                await _typeRepository.CreateAsync(new TypeOfAppointment { });
            }

            if (_appointmentRepository.CountDocuments() == 0)
            {
                await _appointmentRepository.CreateAsync(new Appointment { });
                await _appointmentRepository.CreateAsync(new Appointment { });
                await _appointmentRepository.CreateAsync(new Appointment { });
                await _appointmentRepository.CreateAsync(new Appointment { });
            }

            _patientRepository = null;
            _doctorRepository = null;
            _typeRepository = null;
            _appointmentRepository = null;
        }
    }
}
