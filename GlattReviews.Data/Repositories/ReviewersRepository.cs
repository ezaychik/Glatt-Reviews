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
        private IList<Reviewer> _reviewers = new List<Reviewer>()
        {
            new Reviewer()
            {
                ReviewerId = 1,
                Contact = new Contact()
                {
                    PhoneNumber = 0123456789,
                    Email = "phil@email.email"
                },
                Reviews = new List<Review>()
                {
                    new Review()
                    {
                        ReviewId =1,
                        Date = new DateTime(2021, 10, 22),
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
                        Reviewer = new Reviewer()
                        {
                            ReviewerId = 1,
                            Contact = new Contact()
                            {
                                PhoneNumber = 0123456789,
                                Email = "phil@email.email"
                            },
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
                }
            },
            new Reviewer()
            {
                ReviewerId = 1,
                Contact = new Contact()
                {
                    PhoneNumber = 7894561230,
                    Email = "bill@email.email"
                },
                Reviews = new List<Review>()
                {
                    new Review()
                    {
                        ReviewId =1,
                        Date = new DateTime(2021, 10, 22),
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
                }
            },
            new Reviewer()
            {
                ReviewerId = 1,
                Contact = new Contact()
                {
                    PhoneNumber = 9998887776,
                    Email = "jill@email.email"
                },
                Reviews = new List<Review>()
                {
                    new Review()
                    {
                        ReviewId =1,
                        Date = new DateTime(2021, 10, 22),
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
                }
            },

        };
        public Task<Reviewer> AddAsync(Reviewer entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Reviewer>> GetAllAsync()
        {
            return Task.FromResult(_reviewers);
        }

        public Task<Reviewer> GetByIdAsync(int id)
        {
            var reviewer = _reviewers.FirstOrDefault(r => r.ReviewerId == id);

            return Task.FromResult(reviewer);
        }

        public Task<List<Reviewer>> GetReviewers(int phoneNumber = 0, string email = null)
        {
            if (phoneNumber == 0 && email == null)
            {
                var allReviewers = GetAllAsync().Result;
                return Task.FromResult(allReviewers.ToList());
            }
            else
                return Task.FromResult(_reviewers.Select(r => r).Where(r => r.Contact.Email == email || r.Contact.PhoneNumber == phoneNumber).ToList());
        }

        public Task<List<Review>> GetReviewsById(int id)
        {
            var reviews = _reviewers.Where(r => r.ReviewerId == id).Select(q => q.Reviews).FirstOrDefault();
            return Task.FromResult(reviews);
        }

        public Task<Reviewer> UpdateAsync(Reviewer entity)
        {
            throw new NotImplementedException();
        }
    }
}
