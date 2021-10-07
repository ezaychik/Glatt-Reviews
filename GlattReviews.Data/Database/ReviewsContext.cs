using GlattReviews.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GlattReviews.Data.Database
{
    public class ReviewsContext : DbContext
    {
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }
        public DbSet<ServiceProvider> ServiceProviders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=ReviewsData");
        }
    }
}
