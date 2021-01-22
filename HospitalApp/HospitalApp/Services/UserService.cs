using HospitalApp.Adapters;
using HospitalApp.Contracts;
using HospitalApp.Dtos;
using HospitalApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
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

        public UserDto GetById(int userId)
        {
            User myUser = _dbContext.Users.SingleOrDefault(user => user.Id == userId);

            if (myUser == null) return null;

            return UserAdapter.UserToUserDto(myUser);
        }

        public UserDto UpdateById(int userId, User user)
        {
            User myUser = _dbContext.Users.SingleOrDefault(u => u.Id == userId);

            if (myUser == null) return null;

            SetUserData(myUser, user);

            return UserAdapter.UserToUserDto(myUser);
        }

        public UserDto BlockUser(int userId)
        {
            User myUser = _dbContext.Users.SingleOrDefault(user => user.Id == userId);

            if (myUser == null) return null;

            myUser.IsBlocked = true;
            _dbContext.SaveChanges();

            return GetById(userId);
        }

        public void SetUserData(User oldValues, User newValues)
        {
            oldValues.FirstName = newValues.FirstName;
            oldValues.LastName = newValues.LastName;
            oldValues.Password = newValues.Password;
            oldValues.Address = newValues.Address;
            oldValues.PhoneNumber = newValues.PhoneNumber;
            oldValues.IsBlocked = newValues.IsBlocked;
            oldValues.IsMalicious = newValues.IsMalicious;

            _dbContext.SaveChanges();
        }
    }
}
