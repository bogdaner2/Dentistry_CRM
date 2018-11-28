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
                await _patientRepository.CreateAsync(new Patient { Fullname = "Петро Федорович" , Debt = 0 , Phone = "+380950000098"});
                await _patientRepository.CreateAsync(new Patient { Fullname = "Олександр Федорович", Debt = 100, Phone = "+380950000100" });
                await _patientRepository.CreateAsync(new Patient { Fullname = "Микита Федорович", Debt = -50, Phone = "+380950000111" });
                await _patientRepository.CreateAsync(new Patient { Fullname = "Олег Федорович", Debt = 700, Phone = "+380950000000" });

            }

            if (_doctorRepository.CountDocuments() == 0)
            {
                await _doctorRepository.CreateAsync(new Doctor { Fullname = "Петро Федорович",Chair = 1, Phone = "+380950000098" });
                await _doctorRepository.CreateAsync(new Doctor { Fullname = "Петро Федорович",Chair = 1,Phone = "+380950000098" });
                await _doctorRepository.CreateAsync(new Doctor { Fullname = "Петро Федорович", Chair = 2,Phone = "+380950000098" });
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
