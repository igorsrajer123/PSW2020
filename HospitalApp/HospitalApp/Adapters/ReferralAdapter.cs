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
                Patient = referralDto.Patient,
                Specialist = referralDto.Specialist,
                SpecialistId = referralDto.SpecialistId               
            };

            return referral;
        }

        public static ReferralDto ReferralToReferralDto(Referral referral)
        {
            ReferralDto referralDto = new ReferralDto
            {
                Id = referral.Id,
                Patient = referral.Patient,
                Specialist = referral.Specialist,
                SpecialistId = referral.SpecialistId,
            };

            return referralDto;
        }
    }
}
