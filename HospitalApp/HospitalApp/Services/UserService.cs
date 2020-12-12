using HospitalApp.Adapters;
using HospitalApp.Contracts;
using HospitalApp.Dtos;
using HospitalApp.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace HospitalApp.Services
{
    public class UserService : IUserService
    {
        private MyDbContext _dbContext;

        public UserService(MyDbContext context)
        {
            _dbContext = context;
        }

        public List<UserDto> GetAll()
        {
            List<UserDto> myUsers = new List<UserDto>();

            _dbContext.Users.ToList().ForEach(user => myUsers.Add(UserAdapter.UserToUserDto(user)));

            return myUsers;
        }

        public UserDto UpdateById(int id, User user)
        {
            User myUser = _dbContext.Users.SingleOrDefault(u => u.Id == id);

            if (myUser == null)
                return null;

            myUser.FirstName = user.FirstName;
            myUser.LastName = user.LastName;
            myUser.Password = user.Password;
            myUser.Address = user.Address;
            myUser.PhoneNumber = user.PhoneNumber;
            myUser.IsDeleted = user.IsDeleted;

            _dbContext.SaveChanges();

            return UserAdapter.UserToUserDto(myUser);
        }
    }
}
