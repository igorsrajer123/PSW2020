using HospitalApp.Dtos;
using Microsoft.AspNetCore.Mvc.Testing;
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
    public class AccountController
    {
        private readonly WebApplicationFactory<HospitalApp.Startup> _factory;
        private readonly HttpClient _httpClient;

        public AccountController()
        {
            _factory = new WebApplicationFactory<HospitalApp.Startup>();
            _httpClient = _factory.CreateClient();
        }

        [Fact]
        public async Task Login_success()
        {
            var response = await _httpClient.PostAsync("http://localhost:50324/login/admin/admin", new StringContent("Bad", Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            responseBody.ShouldBe("{\"statusCode\":200}");
        }

        [Fact]
        public async Task Login_failure()
        {
            var response = await _httpClient.PostAsync("http://localhost:50324/login/admin/2", new StringContent("Bad", Encoding.UTF8, "application/json"));
            string responseBody = await response.Content.ReadAsStringAsync();

            responseBody.ShouldContain("Not Found");
        }

        [Fact]
        public async Task Get_session()
        {
            await _httpClient.PostAsync("http://localhost:50324/login/admin/admin", new StringContent("Bad", Encoding.UTF8, "application/json"));
            var response = await _httpClient.GetAsync("http://localhost:50324/getSession");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<AdministratorDto>(responseBody);

            user.Id.ShouldBe(5);
        }

        [Fact]
        public async Task Logout()
        {
            await _httpClient.PostAsync("http://localhost:50324/login/admin/admin", new StringContent("Bad", Encoding.UTF8, "application/json"));
            await _httpClient.DeleteAsync("http://localhost:50324/logout");
            var response = await _httpClient.GetAsync("http://localhost:50324/getSession");
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            responseBody.ShouldBe("");
        }
    }
}
