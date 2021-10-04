using GlattReviews.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlattReviews.Data.Models
{
    public class ReviewerModel
    {
        public int ReviewerId { get; set; }
        public Contact Contact { get; set; }
        public List<ReviewModel> Reviews { get; set; }
    }
}
