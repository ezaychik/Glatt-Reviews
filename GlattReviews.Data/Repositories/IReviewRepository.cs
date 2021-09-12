using GlattReviews.Domain.Entities;

namespace GlattReviews.Application.Repositories.DataAccess
{
    public interface IReviewRepository: IAsyncRepository<Review>
    {
    }
}
