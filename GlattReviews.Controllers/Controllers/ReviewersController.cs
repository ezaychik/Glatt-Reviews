using AutoMapper;
using GlattReviews.Application.Repositories.DataAccess;
using GlattReviews.Data.Models;
using GlattReviews.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlattReviews.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReviewersController : ControllerBase
    {
        private readonly IReviewersRepository _reviewersRepository;
        private readonly IMapper _mapper;
        public ReviewersController(IReviewersRepository reviewersRepository, IMapper mapper)
        {
            _reviewersRepository = reviewersRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewerModel>> GetReviewer(int id)
        {
            try
            {
                var review = await _reviewersRepository.GetByIdAsync(id);
                if (review == null)
                    return NotFound("Review does not exist.");

                return _mapper.Map<ReviewerModel>(review);

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<ReviewerModel>>> GetReviewers([FromQuery] int phoneNumber = 0, [FromQuery] string email = null)
        {
            try
            {

                var results = await _reviewersRepository.GetReviewers(phoneNumber, email);

                if (results.Count < 1)
                    return NotFound("Search criteria did not return any results.");

                return _mapper.Map<List<ReviewerModel>>(results);

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
    }
}
