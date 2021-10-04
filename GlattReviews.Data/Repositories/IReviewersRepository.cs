using GlattReviews.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlattReviews.Application.Repositories.DataAccess
{
    public interface IReviewersRepository : IAsyncRepository<Reviewer>
    {
        Task<List<Reviewer>> GetReviewers(int phoneNumber = 0, string email = null);
    }
}
