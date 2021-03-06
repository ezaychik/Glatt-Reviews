using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlattReviews.Domain.Entities
{
    public class Reviewer
    {
        public int ReviewerId { get; set; }
        public string Email { get; set; }
        public long PhoneNumber { get; set; }
        public string Name { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
