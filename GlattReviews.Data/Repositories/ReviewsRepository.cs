using GlattReviews.Application.Repositories.DataAccess;
using GlattReviews.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlattReviews.Data.Repositories
{
    public class ReviewsRepository : IReviewsRepository
    {

        private IList<Review> _reviews = new List<Review>()
        {
            new Review()
            {
                ReviewId =1,
                Date = new DateTime(2021, 10, 22),
                Reviewer= new Reviewer()
                {
                    ReviewerId = 1,
                    Contact = new Contact()
                    {
                        Email = "email@email.email",
                    }

                },
                ServiceProvider = new ServiceProvider()
                {
                    Name = "Joe",
                    Contact = new Contact()
                    {
                        Email = "joe@email.email",
                    }
                },
                ServiceType = "Legal",

            },
            new Review()
            {
                ReviewId =2,
                Date = new DateTime(2021, 11, 22),
                Reviewer= new Reviewer()
                {
                    ReviewerId = 2,
                    Contact = new Contact()
                    {
                        Email = "email@email.email",
                    }
                },
                ServiceType = "Plumbing",
                ServiceProvider = new ServiceProvider()
                {
                    Name = "Steve",
                    Contact = new Contact()
                    {
                        Email = "steve@email.email",
                    }
                }
            },
            new Review()
            {
                ReviewId =3,
                Date = new DateTime(2021, 12, 22),
                Reviewer= new Reviewer()
                {
                    ReviewerId = 3,
                    Contact = new Contact()
                    {
                        Email = "email@email.email",
                    }
                },
                ServiceType = "Electric",
                ServiceProvider = new ServiceProvider()
                {
                    Name = "Bob",
                    Contact = new Contact()
                    {
                        Email = "bob@email.email",
                    }
                }
            }
        };
        public Task<Review> AddAsync(Review entity)
        {
            _reviews.Add(entity);
            return Task.FromResult(entity);
        }

        public Task<bool> DeleteAsync(int id)
        {
            var indexOfReview = _reviews.IndexOf(_reviews.Select(r => r).Where(r => r.ReviewId == id).FirstOrDefault());
            _reviews.RemoveAt(indexOfReview);
            return Task.FromResult(true);
        }

        public Task<IList<Review>> GetAllAsync()
        {
            return Task.FromResult(_reviews);
        }

        public Task<Review> GetByIdAsync(int id)
        {
            var review = _reviews.FirstOrDefault(r => r.ReviewId == id);

            return Task.FromResult(review);
        }

        public Task<List<Review>> GetReviewsByDate(DateTime date)
        {
            var reviews = _reviews.Select(r => r).Where(r => r.Date == date).ToList();
            return Task.FromResult(reviews);
        }

        public Task<List<Review>> GetReviews(string date = null, string serviceProviderName = null, string serviceType = null)
        {
            //Dictionary<string, object> queryParams = new Dictionary<string, object>();
            //if (date != null)
            //{
            //    queryParams.Add("date", date);
            //    DateTime dateAsDate;
            //    var isValidDate = DateTime.TryParse(date, out dateAsDate);
            //    if (isValidDate)
            //    {
            //        queryParams.Add("date", dateAsDate);
            //    }
            //}
            //if (serviceProviderName != null)
            //{
            //    queryParams.Add("serviceProvideName", serviceProviderName);
            //}
            //if (serviceType != null)
            //{
            //    queryParams.Add("serviceType", serviceType);
            //}
            if (date == null && serviceProviderName == null && serviceType == null)
            {
                return Task.FromResult(_reviews.ToList());
            }
            return Task.FromResult(_reviews.ToList());
        }


        public Task<List<Review>> GetReviewsByServiceProvider(string serviceProvideName)
        {
            var reviews = _reviews.Select(r => r).Where(r => r.ServiceProvider.Name == serviceProvideName).ToList();
            return Task.FromResult(reviews);
        }

        public Task<List<Review>> GetReviewsByServiceType(string serviceType)
        {
            var reviews = _reviews.Select(r => r).Where(r => r.ServiceType == serviceType).ToList();
            return Task.FromResult(reviews);
        }

        public Task<Review> UpdateAsync(Review entity)
        {
            var indexOfReview = _reviews.IndexOf(_reviews.Select(r => r).Where(r => r.ReviewId == entity.ReviewId).FirstOrDefault());

            _reviews[indexOfReview] = entity;
            return Task.FromResult(entity);

        }
    }
}
