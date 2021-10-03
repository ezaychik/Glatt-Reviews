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
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewsRepository _reviewsRepository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public ReviewsController(IReviewsRepository reviewsRepository, IMapper mapper, LinkGenerator linkGenerator)
        {
            _reviewsRepository = reviewsRepository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }


        [HttpGet]
        public async Task<ActionResult<List<ReviewModel>>> GetAllReviews()
        {
            try
            {
                var results = await _reviewsRepository.GetAllAsync();
                return _mapper.Map<List<ReviewModel>>(results);

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewModel>> GetReview(int id)
        {
            try
            {
                var review = await _reviewsRepository.GetByIdAsync(id);
                if (review == null)
                    return NotFound("Review does not exist.");

                return _mapper.Map<ReviewModel>(review);

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
        [HttpGet("search")]
        public async Task<ActionResult<List<ReviewModel>>> GetReviews([FromQuery] string date = null, [FromQuery] string serviceProviderName = null, [FromQuery] string serviceType = null)
        {
            try
            {
                if (date == null && serviceType == null && serviceProviderName == null)
                {
                    var allResults = await _reviewsRepository.GetAllAsync();
                    return _mapper.Map<List<ReviewModel>>(allResults);
                }
                else
                {
                    var results = await _reviewsRepository.GetReviewsByInputs(date, serviceProviderName, serviceType);

                    if (results.Count < 1)
                        return NotFound("Search criteria did not return any results.");

                    return _mapper.Map<List<ReviewModel>>(results);
                }


            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
        [HttpPost()]
        public async Task<ActionResult<ReviewModel>> CreateReview(ReviewModel newReview)
        {
            try
            {

                var newReviewMapped = _mapper.Map<Review>(newReview);
                var review = await _reviewsRepository.AddAsync(newReviewMapped);
                if (review != null)
                {
                    var location = _linkGenerator.GetPathByAction("Get", "Reviews", new { id = review.ReviewId });
                    return Created(location, _mapper.Map<ReviewModel>(review));
                }

                return BadRequest();
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
    }
}
