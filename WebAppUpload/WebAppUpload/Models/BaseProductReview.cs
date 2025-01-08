using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppUpload.Models
{
    public class BaseProductReview
    {

        public int ProductReviewId { get; set; }
        public int ProductID { get; set; }
        public string rating { get; set; }
        public string comment { get; set; }
        public DateTime date { get; set; }
        public string reviewername { get; set; }
        public string reviewerEmail { get; set; }

    }
}