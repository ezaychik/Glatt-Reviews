﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlattReviews.Domain.Entities
{
    public class Reviewer
    {
        public int ReviewerId { get; set; }
        public Contact Contact { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
