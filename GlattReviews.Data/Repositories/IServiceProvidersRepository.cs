using GlattReviews.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlattReviews.Application.Repositories.DataAccess
{
    public interface IServiceProvidersRepository: IAsyncRepository<ServiceProvider>
    {
        Task<List<ServiceProvider>> GetServiceProviders(int phoneNumber = 0, string email = null, string name = null, string serviceType = null);
        Task<List<Review>> GetReviewsById(int id);
    }
}
