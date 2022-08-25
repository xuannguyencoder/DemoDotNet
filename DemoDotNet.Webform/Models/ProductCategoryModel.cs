using DemoDotNet.Webform.Models.Db;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DemoDotNet.Webform.Models
{
    public class ProductCategoryModel
    {
        ConnectDB db = null;
        public ProductCategoryModel()
        {
            db = new ConnectDB();
        }
        public List<ProductCategory> GetAll()
        {
            string query = "SELECT * FROM product_category";
            DataTable dt = db.GetData(query);
            List<ProductCategory> categories = new List<ProductCategory>();
            ProductCategory category;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                category = new ProductCategory();
                category.ID = int.Parse(dt.Rows[i]["ID"].ToString());
                category.Name = dt.Rows[i]["Name"].ToString();
                category.Description = dt.Rows[i]["Description"].ToString();
                category.Status = dt.Rows[i]["Status"].ToString().Equals("1") ? true : false;
                categories.Add(category);
            }
            return categories;
        }
    }
}