using HospitalApp.Models;
using HospitalApp.Services;
using Xunit;

namespace HospitalAppTests
{
    public class UserActionsTests
    {
        [Fact]
        public void Register_new_user()
        {
            UserService service = new UserService(null);
        }
    }
}
