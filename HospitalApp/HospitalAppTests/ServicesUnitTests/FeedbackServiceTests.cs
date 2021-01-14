using HospitalApp.Dtos;
using HospitalApp.Models;
using HospitalApp.Services;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HospitalAppTests.ServicesTests
{
    public class FeedbackServiceTests
    {
        private DbContextOptions<MyDbContext> _options;

        public FeedbackServiceTests()
        {
            _options = new DbContextOptionsBuilder<MyDbContext>().UseInMemoryDatabase(databaseName: "FeedbacksDb").Options;
        }
        
        [Fact]
        public void Get_all_feedbacks()
        {
            using (var context = new MyDbContext(_options))
            {
                SetupDatabase(context);
                FeedbackService service = new FeedbackService(context);

                List<FeedbackDto> feedbacks = service.GetAll();

                feedbacks.Count.ShouldBeGreaterThanOrEqualTo(2);
            }
        }

        [Fact]
        public void Get_by_id()
        {
            using (var context = new MyDbContext(_options))
            {
                SetupDatabase(context);
                FeedbackService service = new FeedbackService(context);

                FeedbackDto feedback = service.GetById(1);

                feedback.Id.ShouldBe(1);
            }
        }

        [Fact]
        public void Get_visible_feedbacks()
        {
            using (var context = new MyDbContext(_options))
            {
                SetupDatabase(context);
                FeedbackService service = new FeedbackService(context);

                List<FeedbackDto> visibleFeedbacks = service.GetVisibleFeedbacks();

                visibleFeedbacks.Count.ShouldBe(1);
            }
        }

        [Fact]
        public void Hide_feedback()
        {
            using (var context = new MyDbContext(_options))
            {
                SetupDatabase(context);
                FeedbackService service = new FeedbackService(context);

                FeedbackDto feedback = service.HideFeedback(2);

                feedback.IsVisible.ShouldBe(false);
            }
        }

        [Fact]
        public void Show_feedback()
        {
            using (var context = new MyDbContext(_options))
            {
                SetupDatabase(context);
                FeedbackService service = new FeedbackService(context);

                FeedbackDto feedback = service.ShowFeedback(1);

                feedback.IsVisible.ShouldBe(true);
            }
        }

        private void CreateFeedbacks(MyDbContext context)
        {
            context.Feedbacks.Add(new Feedback
            { 
                Id = 1,
                Date = "",
                IsDeleted = false,
                IsVisible = false,
                PatientId = 11,
                Text = "!!!!!@#"
            });

            context.Feedbacks.Add(new Feedback
            {
                Id = 2,
                Date = "",
                IsDeleted = false,
                IsVisible = true,
                PatientId = 12,
                Text = "!!!!!@#"
            });

            context.SaveChanges();
        }

        private void CreatePatients(MyDbContext context)
        {
            context.Patients.Add(new Patient
            {
                Id = 11,
                Age = 12,
                Address = "Frankopanova",
                CancelledAppointments = 1,
                FirstName = "Strahinja",
                LastName = "Egic",
                Gender = "Male",
                IsBlocked = false,
                Password = "123",
                IsMalicious = false,
                PhoneNumber = "0000",
                Username = "patient123",
                GeneralPractitionerId = 21,
                Role = "Patient"
            });

            context.Patients.Add(new Patient
            {
                Id = 12,
                Age = 22,
                Address = "Sergeja Cetkovica 2",
                CancelledAppointments = 3,
                FirstName = "Samir",
                LastName = "Samirovic",
                Gender = "Male",
                IsBlocked = false,
                Password = "123",
                IsMalicious = true,
                PhoneNumber = "0000",
                Username = "patient2",
                GeneralPractitionerId = null,
                Role = "Patient"
            });

            context.SaveChanges();
        }

        private void SetupDatabase(MyDbContext context)
        {
            context.Database.EnsureDeleted();
            CreateFeedbacks(context);
            CreatePatients(context);
        }
    }
}
