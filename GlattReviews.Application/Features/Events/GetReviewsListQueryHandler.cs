using AutoMapper;
using GlattReviews.Application.Repositories.DataAccess;
using GlattReviews.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GlattReviews.Application.Features.Events
{
    public class GetReviewsListQueryHandler : IRequestHandler<GetReviewsListQuery, List<ReviewRepresentation>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Review> _reviewRepository;

        public GetReviewsListQueryHandler(IMapper mapper, IAsyncRepository<Review> reviewRepository)
        {
            _mapper = mapper;
            _reviewRepository = reviewRepository;
        }
        public async Task<List<ReviewRepresentation>> Handle(GetReviewsListQuery request, CancellationToken cancellationToken)
        {
            var allReviews = (await _reviewRepository.GetAllAsync()).OrderBy(r => r.Date);
            return _mapper.Map<List<ReviewRepresentation>>(allReviews);
        }
    }
}
