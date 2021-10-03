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
                .ForMember(r => r.ServiceProviderName, o => o.MapFrom(m => m.ServiceProvider.Name))
                .ForPath(r => r.ReviewerContact.Email, o => o.MapFrom(m => m.Reviewer.Contact.Email))
                .ForPath(r => r.ReviewerContact.PhoneNumber, o => o.MapFrom(m => m.Reviewer.Contact.PhoneNumber))
                .ForPath(r => r.ServiceProviderContact.Email, o => o.MapFrom(m => m.ServiceProvider.Contact.Email))
                .ForPath(r => r.ServiceProviderContact.PhoneNumber, o => o.MapFrom(m => m.ServiceProvider.Contact.PhoneNumber)
                );
        }
    }
}
