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

        public Task DeleteAsync(ServiceProvider entity)
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

        public Task UpdateAsync(ServiceProvider entity)
        {
            throw new NotImplementedException();
        }
    }
}
