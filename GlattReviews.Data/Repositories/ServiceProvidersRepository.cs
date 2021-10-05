using GlattReviews.Application.Repositories.DataAccess;
using GlattReviews.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlattReviews.Data.Repositories
{
    public class ServiceProvidersRepository : IServiceProvidersRepository
    {
        public Task<ServiceProvider> AddAsync(ServiceProvider entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<ServiceProvider>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceProvider> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Review>> GetReviewsById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ServiceProvider>> GetServiceProviders(int phoneNumber = 0, string email = null, string name = null, string serviceType = null)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceProvider> UpdateAsync(ServiceProvider entity)
        {
            throw new NotImplementedException();
        }
    }
}
