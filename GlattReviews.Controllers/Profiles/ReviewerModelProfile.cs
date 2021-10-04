using AutoMapper;
using GlattReviews.Data.Models;
using GlattReviews.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlattReviews.API.Profiles
{
    public class ReviewerModelProfile : Profile
    {
        public ReviewerModelProfile()
        {
            CreateMap<Reviewer, ReviewerModel>();
        }
    }
}
