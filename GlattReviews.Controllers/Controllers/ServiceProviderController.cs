using AutoMapper;
using GlattReviews.Application.Repositories.DataAccess;
using GlattReviews.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlattReviews.API.Controllers
{
    public class ServiceProviderController: ControllerBase
    {
        [Route("[controller]")]
        [ApiController]
        public class ReviewersController : ControllerBase
        {
            private readonly IServiceProvidersRepository _serviceProvidersRepository;
            private readonly IMapper _mapper;

            public ReviewersController(IServiceProvidersRepository serviceProvidersRepository, IMapper mapper)
            {
                _serviceProvidersRepository = serviceProvidersRepository;
                _mapper = mapper;
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<ServiceProvideModel>> GetReviewer(int id)
            {
                try
                {
                    var review = await _serviceProvidersRepository.GetByIdAsync(id);
                    if (review == null)
                        return NotFound("Review does not exist.");

                    return _mapper.Map<ServiceProvideModel>(review);

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

                    var results = await _serviceProvidersRepository.GetServiceProviders(phoneNumber, email);

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
}
