using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GlattReviews.API.Controllers
{
    [Route("[controller]")]
    public class ReviewsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetReviews()
        {
            try
            {
                return Ok(new { Id = 1, Name = "Some Review" });

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
    }
}
