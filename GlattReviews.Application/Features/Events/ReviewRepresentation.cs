using GlattReviews.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlattReviews.Application.Features.Events
{
    public class ReviewRepresentation
    {
        public int ReviewId { get; set; }
        public DateTime Date { get; set; }
        public ServiceProvider ServiceProvider { get; set; }
        public string ServiceType { get; set; }
        public Reviewer Reviewer { get; set; }
    }
}
