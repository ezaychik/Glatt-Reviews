using AutoMapper;
using GlattReviews.Data.Models;
using GlattReviews.Domain.Entities;

namespace GlattReviews.Data.Profiles
{
    public class ReviewModelProfile : Profile
    {
        public ReviewModelProfile()
        {
            CreateMap<Review, ReviewModel>()
                .ForPath(r => r.Reviewer.Email, o => o.MapFrom(m => m.Reviewer.Email))
                .ForPath(r => r.Reviewer.PhoneNumber, o => o.MapFrom(m => m.Reviewer.PhoneNumber))
                .ForPath(r => r.Reviewer.Name, o => o.MapFrom(m => m.Reviewer.Name))
                .ForPath(r => r.Reviewer.Reviews, o => o.Ignore())
                .ForPath(r => r.ServiceProvider.Email, o => o.MapFrom(m => m.ServiceProvider.Email))
                .ForPath(r => r.ServiceProvider.PhoneNumber, o => o.MapFrom(m => m.ServiceProvider.PhoneNumber))
                .ForPath(r => r.ServiceProvider.Reviews, o => o.Ignore())
                .ForSourceMember(r => r.ReviewerId, rm=>rm.DoNotValidate())
                .ForSourceMember(r => r.ServiceProviderId, rm => rm.DoNotValidate()
                );
        }
    }
}
