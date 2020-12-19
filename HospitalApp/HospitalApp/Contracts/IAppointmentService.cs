using HospitalApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Contracts
{
    public interface IAppointmentService
    {
        public List<AppointmentDto> GetAll();

        public AppointmentDto Add(AppointmentDto appointmentDto);

        public List<AppointmentDto> GetPatientAppointments(int patientId);

        public AppointmentDto CancelAppointment(int appointmentId);
    }
}
