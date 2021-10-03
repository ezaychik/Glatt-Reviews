using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlattReviews.Domain.Entities
{
    public class ServiceProvider
    {
        public int ServiceProviderId { get; set; }
        public Contact Contact { get; set; }
        public string Name { get; set; }
        public string ServiceCategory { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
