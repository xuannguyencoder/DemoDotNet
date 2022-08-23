using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DemoDotNet.WebMVC.Models.EF
{
    public class DemoDotNetDbContext : DbContext
    {
        public DemoDotNetDbContext() : base("DemoDotNetEntities")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
    }
}