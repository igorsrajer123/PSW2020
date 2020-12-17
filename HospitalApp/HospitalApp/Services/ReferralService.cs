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

        public ReferralDto Add(ReferralDto referralDto)
        {
            if (referralDto == null)
                return null;

            Referral referral = ReferralAdapter.ReferralDtoToReferral(referralDto);
            int doctorId = referralDto.SpecialistId;
            int patientId = referralDto.PatientId;

            Doctor doctor2 = _dbContext.Doctors.SingleOrDefault(d => d.Id == doctorId);
            doctor2.Referrals.Add(referral);

            Patient patient = _dbContext.Patients.SingleOrDefault(p => p.Id == patientId);
            patient.Referral = null;
            patient.Referral = referral;

            _dbContext.Referrals.Add(referral);
            _dbContext.SaveChanges();

            return referralDto;
        }
    }
}
