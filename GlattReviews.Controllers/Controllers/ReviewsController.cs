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
        [HttpGet]
        public async Task<ActionResult<List<ReviewModel>>> GetReviews([FromQuery] string date = null, [FromQuery] string serviceProviderName = null, [FromQuery] string serviceType = null)
        {
            try
            {
                var results = await _reviewsRepository.GetReviews(date, serviceProviderName, serviceType);

                if (results.Count < 1)
                    return NotFound("Search criteria did not return any results.");

                return _mapper.Map<List<ReviewModel>>(results);


            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
        [HttpPost]
        public async Task<ActionResult<ReviewModel>> CreateReview(ReviewModel newReview)
        {
            try
            {
                if (newReview == null)
                    return BadRequest("Please check model.");

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
        [HttpPut("{id}")]
        public async Task<ActionResult<ReviewModel>> UpdateReview(int id, ReviewModel reviewToUpdate)
        {
            try
            {
                if (reviewToUpdate == null)
                    return BadRequest("Please check model.");

                var oldReview = await _reviewsRepository.GetByIdAsync(id);
                if (oldReview == null)
                {
                    return NotFound("Review does not exist.");
                }

                _mapper.Map(reviewToUpdate, oldReview);

                var updatedReview = await _reviewsRepository.UpdateAsync(oldReview);
                if (updatedReview != null)
                {
                    return _mapper.Map<ReviewModel>(updatedReview);
                }

                return BadRequest();
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ReviewModel>> DeleteReview(int id)
        {
            try
            {

                var oldReview = await _reviewsRepository.GetByIdAsync(id);
                if (oldReview == null)
                {
                    return NotFound("Review does not exist.");
                }


                var deleteSuccesful = await _reviewsRepository.DeleteAsync(id);
                if (deleteSuccesful == true)
                {
                    return Ok();
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
