using HospitalApp.Contracts;
using HospitalApp.Dtos;
using HospitalApp.Models;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "Administrator")]
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

        [Authorize(Roles = "Patient")]
        [HttpPost]
        [Route("/addFeedback")]
        public IActionResult Add(FeedbackDto feedbackDto)
        {
            if (_feedbackService.Add(feedbackDto) == null)
                return NotFound();

            return Ok(feedbackDto);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut]
        [Route("/showFeedback/{feedbackId}")]
        public IActionResult ShowFeedback(int feedbackId)
        {
            if (_feedbackService.ShowFeedback(feedbackId) == null)
                return NotFound();

            return Ok(_feedbackService.ShowFeedback(feedbackId));
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut]
        [Route("/hideFeedback/{feedbackId}")]
        public IActionResult HideFeedback(int feedbackId)
        {
            if (_feedbackService.HideFeedback(feedbackId) == null)
                return NotFound();

            return Ok(_feedbackService.HideFeedback(feedbackId));
        }

        [HttpGet]
        [Route("/getVisibleFeedbacks")]
        public IActionResult GetVisibleFeedbacks()
        {
            if (_feedbackService.GetVisibleFeedbacks() == null)
                return NotFound();

            return Ok(_feedbackService.GetVisibleFeedbacks());
        }
    }
}
