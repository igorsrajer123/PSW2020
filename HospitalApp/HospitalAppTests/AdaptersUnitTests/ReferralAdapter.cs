﻿using HospitalApp.Adapters;
using HospitalApp.Dtos;
using HospitalApp.Models;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HospitalAppTests.AdaptersTests
{
    public class ReferralAdapter
    {
        [Fact]
        public void Referral_to_referral_dto()
        {
            Referral referral = CreateReferral();

            ReferralDto myReferral = HospitalApp.Adapters.ReferralAdapter.ReferralToReferralDto(referral);

            myReferral.ShouldBeOfType(typeof(ReferralDto));
        }

        [Fact]
        public void Referral_dto_to_referral()
        {
            ReferralDto referral = CreateReferralDto();

            Referral myReferral = HospitalApp.Adapters.ReferralAdapter.ReferralDtoToReferral(referral);

            myReferral.ShouldBeOfType(typeof(Referral));
        }

        #region "Helper functions"
        private ReferralDto CreateReferralDto()
        {
            return new ReferralDto
            {
                Id = 3,
                IsDeleted = false,
                PatientId = 2,
                SpecialistId = 1
            };
        }

        private Referral CreateReferral()
        {
            return new Referral
            {
                Id = 3,
                IsDeleted = false,
                PatientId = 2,
                SpecialistId = 1
            };
        }
        #endregion
    }
}
