using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppUpload.Models
{
    public class BaseProductImage
    {

        public int ProductImageId { get; set; }
        public int ProductID { get; set; }
        public string ImageType { get; set; }
        public string ImageUrl { get; set; }

    }
}