using HospitalApp.Dtos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HospitalAppTests.IntegrationTests
{
    public class UserControllerTests
    {
        private readonly WebApplicationFactory<HospitalApp.Startup> _factory;
        private readonly HttpClient _httpClient;

      public UserControllerTests()
        {
            _factory = new WebApplicationFactory<HospitalApp.Startup>();
            _httpClient = _factory.CreateClient();
        }

        [Fact]
        public async Task Get_by_id()
        {
            var response = await _httpClient.GetAsync("http://localhost:50324/getUserById/" + 5);

            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserDto>(responseBody);

            user.Id.ShouldBe(5);
        }
    }
}
