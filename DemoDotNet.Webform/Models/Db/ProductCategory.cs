using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoDotNet.Webform.Models.Db
{
    public class ProductCategory
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public bool Status { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }
    }
}