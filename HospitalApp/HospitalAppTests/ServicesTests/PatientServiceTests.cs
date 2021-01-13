using HospitalApp.Adapters;
using HospitalApp.Dtos;
using HospitalApp.Models;
using HospitalApp.Services;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HospitalAppTests.ServicesTests
{
    public class PatientServiceTests
    {
        private InMemoryDatabase _dataBase;
        private PatientService _service;

        public PatientServiceTests()
        {
            _dataBase = new InMemoryDatabase();
            _service = new PatientService(_dataBase.Context, null);
            _dataBase.CheckIfContextEmpty();
        }

        [Fact]
        public void Get_all_patients()
        {
            List<PatientDto> patients = _service.GetAll();

            patients.Count.ShouldBe(GetPatientCount().Result);
        }

        [Fact]
        public void Get_by_id()
        {
            PatientDto patient = _service.GetById(11);

            patient.Id.ShouldBe(11);
        }

        [Fact]
        public void Set_general_practitioner()
        {
            PatientDto patient = _service.SetGeneralPractitioner(11, 21);

            Assert.Equal(21, patient.GeneralPractitionerId);
        }

        [Fact]
        public void Get_appointment_patient()
        {
            PatientDto patient = _service.GetAppointmentPatient(1);

            Assert.Equal(11, patient.Id);
        }
        /*
        [Fact]
        public void Set_random_general_practitioner()
        {
            PatientDto patient = _service.GetById(12);
            Patient k = PatientAdapter.PatientDtoToPatient(patient);
            _service.GiveRandomGeneralPractitioner(k);

            Assert.Equal(21, patient.GeneralPractitionerId);
        }*/

        private async Task<int> GetPatientCount()
        {
            return await _dataBase.Context.Patients.CountAsync();
        }
    }
}
