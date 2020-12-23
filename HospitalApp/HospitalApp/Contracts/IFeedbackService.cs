using HospitalApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Contracts
{
    public interface IFeedbackService
    {
        public List<FeedbackDto> GetAll();

        public FeedbackDto GetById(int feedbackId);

        public FeedbackDto Add(FeedbackDto feedbackDto);

        public FeedbackDto HideFeedback(int feedbackId);

        public FeedbackDto ShowFeedback(int feedbackId);
    }
}
