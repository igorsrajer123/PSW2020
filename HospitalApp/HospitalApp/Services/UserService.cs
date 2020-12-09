using HospitalApp.Contracts;
using HospitalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Services
{
    public class UserService : IUserService
    {
        private MyDbContext _dbContext;

        public UserService(MyDbContext context)
        {
            _dbContext = context;
        }

        public List<User> GetAll()
        {
            List<User> users = new List<User>();

            _dbContext.Users.ToList().ForEach(user => users.Add(user));

            return users;
        }
    }
}
