using HospitalApp.Dtos;
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

        ReferralDto DeleteReferral(int referralId);
    }
}
