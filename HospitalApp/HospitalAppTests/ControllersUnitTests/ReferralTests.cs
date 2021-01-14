using HospitalApp.Contracts;
using HospitalApp.Controllers;
using HospitalApp.Dtos;
using HospitalApp.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xunit;

namespace HospitalAppTests
{
    public class ReferralTests
    {
        [Fact]
        public void Get_all_referrals()
        {
            ReferralController controller = new ReferralController(SetupRepository(null).Object);

            var actionResult = controller.GetAll();

            ConvertToList(actionResult).ShouldBeEquivalentTo(CreateReferrals());
        }
       
        [Fact]
        public void Get_by_id()
        {
            ReferralController controller = new ReferralController(SetupRepository(null).Object);

            var actionResult = controller.GetById(1);

            ConvertToObject(actionResult).ShouldBeEquivalentTo(CreateReferrals().Find(r => r.Id == 1));
        }

        [Fact]
        public void Add_referral()
        {
            ReferralDto referral = CreateReferral();
            ReferralController controller = new ReferralController(SetupRepository(referral).Object);

            var actionResult = controller.Add(referral);

            ConvertToObject(actionResult).ShouldBeEquivalentTo(referral);
        }

        private Mock<IReferralService> CreateRepository()
        {
            return new Mock<IReferralService>();
        }

        private List<ReferralDto> CreateReferrals()
        {
            var referrals = new List<ReferralDto>();

            ReferralDto referral1 = new ReferralDto
            {
                Id = 1,
                IsDeleted = false,
                PatientId = 1,
                SpecialistId = 1
            };

            ReferralDto referral2 = new ReferralDto
            {
                Id = 2,
                IsDeleted = false,
                PatientId = 2,
                SpecialistId = 2
            };

            referrals.Add(referral1);
            referrals.Add(referral2);

            return referrals;
        }

        private ReferralDto CreateReferral()
        {
            return new ReferralDto
            {
                Id = 3,
                IsDeleted = false,
                PatientId = 2,
                SpecialistId = 1
            };
        }

        private ReferralDto ConvertToObject(IActionResult actionResult)
        {
            return (actionResult as OkObjectResult).Value as ReferralDto;
        }

        private List<ReferralDto> ConvertToList(IActionResult actionResult)
        {
            return (actionResult as OkObjectResult).Value as List<ReferralDto>;
        }

        private string GetCallingMethod()
        {
            StackTrace stackTrace = new StackTrace();
            return stackTrace.GetFrame(2).GetMethod().Name;
        }

        private Mock<IReferralService> SetupRepository(ReferralDto referral)
        {
            var repository = CreateRepository();
            ReferralDto myReferral = CreateReferrals().Find(r => r.Id == 1);

            if (GetCallingMethod() == "Get_all_referrals")
                repository.Setup(r => r.GetAll()).Returns(CreateReferrals());

            if (GetCallingMethod() == "Get_by_id")
                repository.Setup(r => r.GetById(1)).Returns(myReferral);

            if(GetCallingMethod() == "Add_referral")
                repository.Setup(r => r.Add(referral)).Returns(referral);

            return repository;
        }
    }
}
