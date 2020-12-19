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
    public class ReferralService : IReferralService
    {
        private MyDbContext _dbContext;

        public ReferralService(MyDbContext context)
        {
            this._dbContext = context;
        }

        public List<ReferralDto> GetAll()
        {
            List<ReferralDto> allReferrals = new List<ReferralDto>();

            _dbContext.Referrals.ToList().ForEach(referral => allReferrals.Add(ReferralAdapter.ReferralToReferralDto(referral)));

            return allReferrals;
        }

        public ReferralDto GetById(int referralId)
        {
            Referral referral = _dbContext.Referrals.SingleOrDefault(r => r.Id == referralId);

            if (referral == null)
                return null;

            return ReferralAdapter.ReferralToReferralDto(referral);
        }

        public ReferralDto Add(ReferralDto referralDto)
        {
            if (referralDto == null)
                return null;

            Referral referral = ReferralAdapter.ReferralDtoToReferral(referralDto);

            Doctor doctor = _dbContext.Doctors.SingleOrDefault(d => d.Id == referralDto.SpecialistId);
            Patient patient = _dbContext.Patients.SingleOrDefault(p => p.Id == referralDto.PatientId);

            doctor.Referrals.Add(referral);
            patient.Referral = null;
            patient.Referral = referral;

            _dbContext.Referrals.Add(referral);
            _dbContext.SaveChanges();

            return referralDto;
        }
    }
}
