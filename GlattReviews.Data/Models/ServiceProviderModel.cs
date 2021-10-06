using GlattReviews.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlattReviews.Data.Models
{
    public class ServiceProvideModel
    {
        public int ServiceProviderId { get; set; }
        public string Email { get; set; }
        public long PhoneNumber { get; set; }
        public string Name { get; set; }
        public string ServiceCategory { get; set; }
        public List<ReviewModel> Reviews { get; set; }
    }
}
