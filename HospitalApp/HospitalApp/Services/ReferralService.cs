using HospitalApp.Adapters;
using HospitalApp.Contracts;
using HospitalApp.Dtos;
using HospitalApp.Models;
using Microsoft.EntityFrameworkCore;
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
            Referral myReferral = _dbContext.Referrals.SingleOrDefault(referral => referral.Id == referralId);

            if (myReferral == null) return null;

            return ReferralAdapter.ReferralToReferralDto(myReferral);
        }

        public ReferralDto Add(ReferralDto referralDto)
        {
            if (referralDto == null) return null;

            Referral referral = ReferralAdapter.ReferralDtoToReferral(referralDto);
            GivePatientReferral(_dbContext.Patients.SingleOrDefault(patient => patient.Id == referralDto.PatientId), referral);
           
            _dbContext.Doctors.SingleOrDefault(doctor => doctor.Id == referralDto.SpecialistId).Referrals.Add(referral);
            _dbContext.Referrals.Add(referral);
            _dbContext.SaveChanges();

            return referralDto;
        }

        public void GivePatientReferral(Patient patient, Referral referral) 
        {
            if (patient.Referral != null)
                RemovePatientsReferral(patient);

            patient.Referral = referral;
        }

        public void RemovePatientsReferral(Patient patient)
        {
            patient.Referral.IsDeleted = true;
            _dbContext.Referrals.Remove(patient.Referral);
            _dbContext.SaveChanges();
        }  

        public ReferralDto GetAppointmentsReferral(Appointment appointment)
        {
            Referral myReferral = _dbContext.Referrals.SingleOrDefault(referral => 
                                  referral.PatientId == appointment.Patient.Id && 
                                  referral.SpecialistId == appointment.DoctorId);

            if (myReferral == null) return null;

            return ReferralAdapter.ReferralToReferralDto(myReferral);
        }
    }
}
