using HospitalApp.Contracts;
using HospitalApp.Dtos;
using HospitalApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpGet]
        [Route("/getAllFeedbacks")]
        public IActionResult GetAll()
        {
            if (_feedbackService.GetAll() == null)
                return NotFound();

            return Ok(_feedbackService.GetAll());
        }

        [HttpGet]
        [Route("/getFeedbackById/{feedbackId}")]
        public IActionResult GetById(int feedbackId)
        {
            if (_feedbackService.GetById(feedbackId) == null)
                return NotFound();

            return Ok(_feedbackService.GetById(feedbackId));
        }

        [HttpPost]
        [Route("/addFeedback")]
        public IActionResult Add(FeedbackDto feedbackDto)
        {
            if (_feedbackService.Add(feedbackDto) == null)
                return NotFound();

            return Ok();
        }

        [HttpPut]
        [Route("/showFeedback/{feedbackId}")]
        public IActionResult ShowFeedback(int feedbackId)
        {
            if (_feedbackService.ShowFeedback(feedbackId) == null)
                return NotFound();

            return Ok(_feedbackService.ShowFeedback(feedbackId));
        }

        [HttpPut]
        [Route("/hideFeedback/{feedbackId}")]
        public IActionResult HideFeedback(int feedbackId)
        {
            if (_feedbackService.HideFeedback(feedbackId) == null)
                return NotFound();

            return Ok(_feedbackService.HideFeedback(feedbackId));
        }
    }
}
