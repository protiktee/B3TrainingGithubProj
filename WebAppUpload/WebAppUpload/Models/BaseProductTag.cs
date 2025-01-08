using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppUpload.Models
{
    public class BaseProductTag
    {

        public int ProductTagId { get; set; }
        public int ProductID { get; set; }
        public string Tag { get; set; }

    }
}