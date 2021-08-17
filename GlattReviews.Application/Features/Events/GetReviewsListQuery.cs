using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlattReviews.Application.Features.Events
{
    public class GetReviewsListQuery: IRequest<List<ReviewRepresentation>>
    {
    }
}
