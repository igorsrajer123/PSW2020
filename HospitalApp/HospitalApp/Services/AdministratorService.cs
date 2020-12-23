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
    public class AdministratorService : IAdministratorService
    {
        private MyDbContext _dbContext;

        public AdministratorService(MyDbContext context)
        {
            _dbContext = context;
        }

        public List<AdministratorDto> GetAll()
        {
            List<AdministratorDto> myAdmins = new List<AdministratorDto>();

            _dbContext.Administrators.ToList().ForEach(admin => myAdmins.Add(AdministratorAdapter.AdministratoToAdministratorDto(admin)));

            return myAdmins;
        }

        public AdministratorDto GetById(int id)
        {
            Administrator admin = _dbContext.Administrators.SingleOrDefault(admin => admin.Id == id);

            if (admin == null)
                return null;

            return AdministratorAdapter.AdministratoToAdministratorDto(admin);
        }

        public AdministratorDto Add(Administrator administrator)
        {
            if (administrator == null)
                return null;

            _dbContext.Administrators.Add(administrator);
            _dbContext.SaveChanges();

            AdministratorDto adminDto = AdministratorAdapter.AdministratoToAdministratorDto(administrator);

            return adminDto;
        }
    }
}
