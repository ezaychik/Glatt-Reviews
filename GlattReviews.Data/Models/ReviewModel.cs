using GlattReviews.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlattReviews.Data.Models
{
    public class ReviewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public string ServiceProviderName { get; set; }
        [Required]
        public Contact ServiceProviderContact { get; set; }
        [Required]
        public string ServiceType { get; set; }
        [Required]
        public Contact ReviewerContact { get; set; }
    }
}
