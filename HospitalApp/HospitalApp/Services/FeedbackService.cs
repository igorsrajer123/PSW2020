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

            _dbContext.Feedbacks.ToList().ForEach(feedback => myFeedbacks.Add(FeedbackAdapter.FeedbackToFeedbackDto(feedback)));

            return myFeedbacks;
        }

        public FeedbackDto GetById(int feedbackId)
        {
            Feedback myFeedback = _dbContext.Feedbacks.SingleOrDefault(feedback => feedback.Id == feedbackId);

            if(myFeedback == null)
                return null;

            return FeedbackAdapter.FeedbackToFeedbackDto(myFeedback);
        }

        public FeedbackDto Add(FeedbackDto feedbackDto)
        {
            if (feedbackDto == null)
                return null;

            Patient myPatient = _dbContext.Patients.SingleOrDefault(patient => patient.Id == feedbackDto.PatientId);
            RemovePreviousFeedback(feedbackDto, myPatient);

            _dbContext.Feedbacks.Add(FeedbackAdapter.FeedbackDtoToFeedback(feedbackDto));
            _dbContext.SaveChanges();

            return feedbackDto;
        }

        public void RemovePreviousFeedback(FeedbackDto feedbackDto, Patient patient)
        {
            if (patient.Feedback != null)
                _dbContext.Remove(patient.Feedback);

            patient.Feedback = FeedbackAdapter.FeedbackDtoToFeedback(feedbackDto);
        }

        public FeedbackDto HideFeedback(int feedbackId)
        {
            Feedback myFeedback = FeedbackAdapter.FeedbackDtoToFeedback(GetById(feedbackId));
            Patient myPatient = _dbContext.Patients.SingleOrDefault(patient => patient.Id == myFeedback.PatientId);

            if (myFeedback == null)
                return null;

            myFeedback.IsVisible = false;
            myPatient.Feedback.IsVisible = false;
            _dbContext.SaveChanges();

            return FeedbackAdapter.FeedbackToFeedbackDto(myFeedback);
        }

        public FeedbackDto ShowFeedback(int feedbackId)
        {
            Feedback myFeedback = FeedbackAdapter.FeedbackDtoToFeedback(GetById(feedbackId));
            Patient myPatient = _dbContext.Patients.SingleOrDefault(patient => patient.Id == myFeedback.PatientId);

            if (myFeedback == null)
                return null;

            myFeedback.IsVisible = true;
            myPatient.Feedback.IsVisible = true;
            _dbContext.SaveChanges();

            return FeedbackAdapter.FeedbackToFeedbackDto(myFeedback);
        }

        public List<FeedbackDto> GetVisibleFeedbacks()
        {
            List<FeedbackDto> myFeedbacks = new List<FeedbackDto>();
            List<Feedback> visibleFeedbacks = _dbContext.Feedbacks.Where(feedback => feedback.IsVisible == true).ToList();

            visibleFeedbacks.ForEach(feedback => myFeedbacks.Add(FeedbackAdapter.FeedbackToFeedbackDto(feedback)));

            return myFeedbacks;
        }
    }
}
