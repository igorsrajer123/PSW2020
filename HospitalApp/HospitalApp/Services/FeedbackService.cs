using HospitalApp.Adapters;
using HospitalApp.Contracts;
using HospitalApp.Dtos;
using HospitalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Services
{
    public class FeedbackService : IFeedbackService
    {
        private MyDbContext _dbContext;

        public FeedbackService(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<FeedbackDto> GetAll()
        {
            List<FeedbackDto> myFeedbacks = new List<FeedbackDto>();

            _dbContext.Feedbacks.ToList().ForEach(f => myFeedbacks.Add(FeedbackAdapter.FeedbackToFeedbackDto(f)));

            return myFeedbacks;
        }

        public FeedbackDto GetById(int feedbackId)
        {
            Feedback myFeedback = _dbContext.Feedbacks.SingleOrDefault(f => f.Id == feedbackId);

            if(myFeedback == null)
                return null;

            return FeedbackAdapter.FeedbackToFeedbackDto(myFeedback);
        }

        public FeedbackDto Add(FeedbackDto feedbackDto)
        {
            Patient patient = _dbContext.Patients.SingleOrDefault(p => p.Id == feedbackDto.PatientId);

            if (feedbackDto == null || patient == null)
                return null;

            _dbContext.Remove(patient.Feedback);
            Feedback feedback = FeedbackAdapter.FeedbackDtoToFeedback(feedbackDto);
            patient.Feedback = feedback;
            _dbContext.Feedbacks.Add(feedback);
            _dbContext.SaveChanges();

            return feedbackDto;
        }

        public FeedbackDto HideFeedback(int feedbackId)
        {
            Feedback myFeedback = FeedbackAdapter.FeedbackDtoToFeedback(GetById(feedbackId));
            Patient patient = _dbContext.Patients.SingleOrDefault(p => p.Id == myFeedback.PatientId);

            if (myFeedback == null || patient == null)
                return null;

            myFeedback.IsVisible = false;
            patient.Feedback.IsVisible = false;
            _dbContext.SaveChanges();

            return FeedbackAdapter.FeedbackToFeedbackDto(myFeedback);
        }

        public FeedbackDto ShowFeedback(int feedbackId)
        {
            Feedback myFeedback = FeedbackAdapter.FeedbackDtoToFeedback(GetById(feedbackId));
            Patient patient = _dbContext.Patients.SingleOrDefault(p => p.Id == myFeedback.PatientId);

            if (myFeedback == null || patient == null)
                return null;

            myFeedback.IsVisible = true;
            patient.Feedback.IsVisible = true;
            _dbContext.SaveChanges();

            return FeedbackAdapter.FeedbackToFeedbackDto(myFeedback);
        }

        public List<FeedbackDto> GetVisibleFeedbacks()
        {

            List<FeedbackDto> myFeedbacks = new List<FeedbackDto>();

            List<Feedback> visibleFeedbacks = _dbContext.Feedbacks.Where(f => f.IsVisible == true).ToList();

            visibleFeedbacks.ForEach(f => myFeedbacks.Add(FeedbackAdapter.FeedbackToFeedbackDto(f)));

            return myFeedbacks;
        }
    }
}
