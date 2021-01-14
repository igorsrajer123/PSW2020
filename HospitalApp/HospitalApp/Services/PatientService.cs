using HospitalApp.Adapters;
using HospitalApp.Contracts;
using HospitalApp.Dtos;
using HospitalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Services
{
    public class PatientService : IPatientService
    {
        private MyDbContext _dbContext;
        private IDoctorService _doctorService;

        public PatientService(MyDbContext context, IDoctorService doctorService)
        {
            _dbContext = context;
            _doctorService = doctorService;
        }

        public List<PatientDto> GetAll()
        {
            List<PatientDto> myPatients = new List<PatientDto>();

            _dbContext.Patients.ToList().ForEach(patient => myPatients.Add(PatientAdapter.PatientToPatientDto(patient)));

            return myPatients;
        }

        public PatientDto GetById(int patientId)
        {
            Patient patient = _dbContext.Patients.SingleOrDefault(p => p.Id == patientId);

            if (patient == null) return null;

            return PatientAdapter.PatientToPatientDto(patient);
        }

        public PatientDto Add(Patient patient)
        {
            if (patient == null || patient.Password == null)
                return null;

            if (_dbContext.Patients.SingleOrDefault(p => p.Username == patient.Username) != null)
                return null;

            GiveRandomGeneralPractitioner(patient);
            
            _dbContext.Patients.Add(patient);
            _dbContext.SaveChanges();

            return PatientAdapter.PatientToPatientDto(patient);
        }

        public void GiveRandomGeneralPractitioner(Patient patient)
        {
            var random = new Random();
            List<DoctorDto> generalPractitioners = _doctorService.GetByType(DoctorType.GeneralPractitioner);
            patient.GeneralPractitionerId = generalPractitioners[random.Next(generalPractitioners.Count)].Id;
            patient.Role = "Patient";
        }

        public PatientDto SetGeneralPractitioner(int patientId, int doctorId)
        {
            Patient myPatient = _dbContext.Patients.SingleOrDefault(patient => patient.Id == patientId);

            if (myPatient == null) return null;

            myPatient.GeneralPractitioner = _dbContext.Doctors.SingleOrDefault(doctor => doctor.Id == doctorId);
            _dbContext.SaveChanges();

            return PatientAdapter.PatientToPatientDto(myPatient);
        }

        public PatientDto GetAppointmentPatient(int appointmentId)
        {
            Appointment appointment = _dbContext.Appointments.SingleOrDefault(appointment => appointment.Id == appointmentId);
            Patient myPatient = _dbContext.Patients.SingleOrDefault(patient => patient.Id == appointment.PatientId);

            if (myPatient == null) return null;

            return PatientAdapter.PatientToPatientDto(myPatient);
        }
    }
}
