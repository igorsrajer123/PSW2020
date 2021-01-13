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
    public class DoctorServiceTests
    {
        private InMemoryDatabase _dataBase;
        private DoctorService _service;

        public DoctorServiceTests()
        {
            _dataBase = new InMemoryDatabase();
            _service = new DoctorService(_dataBase.Context);
            _dataBase.CheckIfContextEmpty();
        }
        
        [Fact]
        public void Get_all_doctors()
        {
            List<DoctorDto> doctors = _service.GetAll();

            doctors.Count.ShouldBe(GetDoctorCount().Result);
        }

        [Fact]
        public void Get_by_id()
        {
            DoctorDto doctor = _service.GetById(22);

            Assert.Equal(22, doctor.Id);
        }

        [Fact]
        public void Get_by_type()
        {
            List<DoctorDto> generalPractitioners = _service.GetByType(DoctorType.GeneralPractitioner);

            Assert.Single(generalPractitioners);
        }

        [Fact]
        public void Add()
        {
            DoctorDto newDoctor = new DoctorDto { Id = 23, FirstName = "Doktor", LastName = "Doktorica", Username = "doca3", Type = DoctorType.Specialist};
            DoctorDto doctor = _service.Add(newDoctor);

            Assert.Equal(3, GetDoctorCount().Result);
        }

        private async Task<int> GetDoctorCount()
        {
            return await _dataBase.Context.Doctors.CountAsync();
        }
    }
}
