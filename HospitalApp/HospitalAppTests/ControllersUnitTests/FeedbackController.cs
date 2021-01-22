using HospitalApp.Contracts;
using HospitalApp.Controllers;
using HospitalApp.Dtos;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xunit;

namespace HospitalAppTests
{
    public class FeedbackController
    {
        [Fact]
        public void Get_all_feedbacks()
        {
            HospitalApp.Controllers.FeedbackController controller = new HospitalApp.Controllers.FeedbackController(this.SetupRepository(null).Object);

            var actionResult = controller.GetAll();

            ConvertToList(actionResult).ShouldBeEquivalentTo(CreateFeedbacks());
        }

        [Fact]
        public void Get_by_id()
        {
            FeedbackDto myFeedback = CreateFeedbacks().Find(f => f.Id == 1);
            HospitalApp.Controllers.FeedbackController controller = new HospitalApp.Controllers.FeedbackController(this.SetupRepository(myFeedback).Object);

            var actionResult = controller.GetById(myFeedback.Id);

            ConvertToObject(actionResult).ShouldBeEquivalentTo(myFeedback);
        }

        [Fact]
        public void Get_visible_feedbacks()
        {
            List<FeedbackDto> visibleFeedbacks = CreateFeedbacks().FindAll(f => f.IsVisible == true);
            HospitalApp.Controllers.FeedbackController controller = new HospitalApp.Controllers.FeedbackController(this.SetupRepository(null).Object);
            
            var actionResult = controller.GetVisibleFeedbacks();
            
            ConvertToList(actionResult).ShouldBeEquivalentTo(visibleFeedbacks);
        }

        [Fact]
        public void Add_feedback()
        {
            FeedbackDto feedback = CreateFeedback();
            HospitalApp.Controllers.FeedbackController controller = new HospitalApp.Controllers.FeedbackController(this.SetupRepository(feedback).Object);

            var actionResult = controller.Add(feedback);

            ConvertToObject(actionResult).ShouldBeEquivalentTo(feedback);
        }

        [Fact]
        public void Show_feedback()
        {
            FeedbackDto myFeedback = CreateFeedbacks().Find(f => f.Id == 1);
            myFeedback.IsVisible = true;
            HospitalApp.Controllers.FeedbackController controller = new HospitalApp.Controllers.FeedbackController(this.SetupRepository(myFeedback).Object);

            var actionResult = controller.ShowFeedback(myFeedback.Id);

            Assert.True(ConvertToObject(actionResult).IsVisible);
        }

        [Fact]
        public void Hide_feedback()
        {
            FeedbackDto myFeedback = CreateFeedbacks().Find(f => f.Id == 2);
            myFeedback.IsVisible = false;
            HospitalApp.Controllers.FeedbackController controller = new HospitalApp.Controllers.FeedbackController(this.SetupRepository(myFeedback).Object);

            var actionResult = controller.HideFeedback(myFeedback.Id);

            Assert.True(!ConvertToObject(actionResult).IsVisible);
        }

        #region "Helper function"
        private List<FeedbackDto> CreateFeedbacks()
        {
            var feedbacks = new List<FeedbackDto>();

            FeedbackDto feedback1 = new FeedbackDto
            {
                Id = 1,
                IsDeleted = false,
                IsVisible = false,
                Text = "Text123",
                Date = "1.1.2012",
                PatientId = 1  
            };

            FeedbackDto feedback2 = new FeedbackDto
            {
                Id = 2,
                IsDeleted = false,
                IsVisible = true,
                Text = "ASD",
                Date = "11.1.2012",
                PatientId = 1
            };

            feedbacks.Add(feedback1);
            feedbacks.Add(feedback2);

            return feedbacks;
        }

        private FeedbackDto CreateFeedback()
        {
            return new FeedbackDto
            {
                Id = 3,
                IsDeleted = false,
                IsVisible = true,
                Text = "TEXT!!",
                Date = "11.1.2012",
                PatientId = 2
            };
        }

        private FeedbackDto ConvertToObject(IActionResult actionResult)
        {
            return (actionResult as OkObjectResult).Value as FeedbackDto;
        }

        private List<FeedbackDto> ConvertToList(IActionResult actionResult)
        {
            return (actionResult as OkObjectResult).Value as List<FeedbackDto>;
        }

        private string GetCallingMethod()
        {
            StackTrace stackTrace = new StackTrace();
            return stackTrace.GetFrame(2).GetMethod().Name;
        }

        private Mock<IFeedbackService> CreateRepository()
        {
            return new Mock<IFeedbackService>();
        }

        private Mock<IFeedbackService> SetupRepository(FeedbackDto feedback)
        {
            var repository = CreateRepository();

            switch (GetCallingMethod())
            {
                case "Get_all_feedbacks":
                    repository.Setup(r => r.GetAll()).Returns(CreateFeedbacks());
                    break;
                case "Get_by_id":
                    repository.Setup(r => r.GetById(feedback.Id)).Returns(feedback);
                    break;
                case "Add_feedback":
                    repository.Setup(r => r.Add(feedback)).Returns(feedback);
                    break;
                case "Get_visible_feedbacks":
                    repository.Setup(f => f.GetVisibleFeedbacks()).Returns(CreateFeedbacks().FindAll(f => f.IsVisible == true));
                    break;
                case "Show_feedback":
                    repository.Setup(m => m.ShowFeedback(1)).Returns(feedback);
                    break;
                case "Hide_feedback":
                    repository.Setup(m => m.HideFeedback(2)).Returns(feedback);
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }

            return repository;
        }
        #endregion
    }
}
