using HospitalApp.Dtos;
using HospitalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Adapters
{
    public class ReferralAdapter
    {
        public static Referral ReferralDtoToReferral(ReferralDto referralDto)
        {
            Referral referral = new Referral
            {
                Id = referralDto.Id,
                PatientId = referralDto.PatientId,
                SpecialistId = referralDto.SpecialistId,
                IsDeleted = referralDto.IsDeleted
            };

            return referral;
        }

        public static ReferralDto ReferralToReferralDto(Referral referral)
        {
            ReferralDto referralDto = new ReferralDto
            {
                Id = referral.Id,
                PatientId = referral.PatientId,
                SpecialistId = referral.SpecialistId,
                IsDeleted = referral.IsDeleted
            };

            return referralDto;
        }
    }
}
