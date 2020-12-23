using HospitalApp.Dtos;
using HospitalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Adapters
{
    public class FeedbackAdapter
    {
        public static Feedback FeedbackDtoToFeedback(FeedbackDto feedbackDto)
        {
            Feedback feedback = new Feedback
            {
                Id = feedbackDto.Id,
                PatientId = feedbackDto.PatientId,
                Text = feedbackDto.Text,
                Date = feedbackDto.Date,
                IsDeleted = feedbackDto.IsDeleted,
                IsVisible = feedbackDto.IsVisible
            };

            return feedback;
        }

        public static FeedbackDto FeedbackToFeedbackDto(Feedback feedback)
        {
            FeedbackDto feedbackDto = new FeedbackDto
            {
                Id = feedback.Id,
                PatientId = feedback.PatientId,
                Text = feedback.Text,
                Date = feedback.Date,
                IsDeleted = feedback.IsDeleted,
                IsVisible = feedback.IsVisible
            };

            return feedbackDto;
        }
    }
}
