using HospitalApp.Adapters;
using HospitalApp.Dtos;
using HospitalApp.Models;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HospitalAppTests.AdaptersTests
{
    public class FeedbackAdapter
    {
        [Fact]
        private void Feedback_to_feedback_dto()
        {
            Feedback feedback = CreateFeedback();

            FeedbackDto myFeedback = HospitalApp.Adapters.FeedbackAdapter.FeedbackToFeedbackDto(feedback);

            myFeedback.ShouldBeOfType(typeof(FeedbackDto));
        }

        [Fact]
        private void Feedback_dto_to_feedback()
        {
            FeedbackDto feedback = CreateFeedbackDto();

            Feedback myFeedback = HospitalApp.Adapters.FeedbackAdapter.FeedbackDtoToFeedback(feedback);

            myFeedback.ShouldBeOfType(typeof(Feedback));
        }

        #region "Helper functions"
        private FeedbackDto CreateFeedbackDto()
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

        private Feedback CreateFeedback()
        {
            return new Feedback
            {
                Id = 3,
                IsDeleted = false,
                IsVisible = true,
                Text = "TEXT!!",
                Date = "11.1.2012",
                PatientId = 2
            };
        }
        #endregion
    }
}
