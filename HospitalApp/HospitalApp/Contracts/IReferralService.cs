using HospitalApp.Dtos;
using HospitalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Contracts
{
    public interface IReferralService
    {
        List<ReferralDto> GetAll();

        ReferralDto GetById(int referralId);

        ReferralDto Add(ReferralDto referralDto);

        ReferralDto GetAppointmentsReferral(Appointment appointment);
    }
}
