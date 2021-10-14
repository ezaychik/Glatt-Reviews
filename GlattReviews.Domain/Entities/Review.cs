using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlattReviews.Domain.Entities
{
    public class Review
    {
        public int ReviewId { get; set; }
        public DateTime Date { get; set; }
        public ServiceProvider ServiceProvider { get; set; }
        public int ServiceProviderId { get; set; }
        public string ServiceType { get; set; }
        public Reviewer Reviewer { get; set; }
        public int ReviewerId { get; set; }
    }
}
