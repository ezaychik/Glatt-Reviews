using GlattReviews.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlattReviews.Application.Repositories.DataAccess
{
    public interface IReviewsRepository: IAsyncRepository<Review>
    {
        Task<List<Review>> GetReviews(string date = null, string serviceProviderName = null, string serviceType = null);
    }
}
