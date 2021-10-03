using GlattReviews.Application.Repositories.DataAccess;
using GlattReviews.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlattReviews.Data.Repositories
{
    public class ReviewersRepository : IReviewersRepository
    {
        public Task<Reviewer> AddAsync(Reviewer entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Reviewer entity)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Reviewer>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Reviewer> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Reviewer entity)
        {
            throw new NotImplementedException();
        }
    }
}
