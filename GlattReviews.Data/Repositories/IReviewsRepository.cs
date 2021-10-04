using GlattReviews.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlattReviews.Application.Repositories.DataAccess
{
    public interface IReviewsRepository: IAsyncRepository<Review>
    {
        Task<List<Review>> GetReviewsByInputs(string date = null, string serviceProviderName = null, string serviceType = null);
        //Task<List<Review>> GetReviewsByServiceProvider(string serviceProvideName);
        //Task<List<Review>> GetReviewsByServiceType(string serviceType);
    }
}
