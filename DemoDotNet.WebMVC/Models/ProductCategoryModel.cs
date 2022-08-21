using DemoDotNet.WebMVC.Models.EF;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DemoDotNet.WebMVC.Models
{
    public class ProductCategoryModel
    {
        DemoDotNetDbContext db = null;
        public ProductCategoryModel()
        {
            db = new DemoDotNetDbContext();
        }
        public List<ProductCategory> GetAll()
        {
            var list = db.Database.SqlQuery<ProductCategory>("Sp_ProductCategory_GetAll").ToList();
            return list;
        }
        public ProductCategory GetByID(int? ID)
        {
            var result = db.Database.SqlQuery<ProductCategory>("Sp_ProductCategory_GetByID {0}", ID).SingleOrDefault();
            return result;
        }

        public int Insert(ProductCategory productCategory)
        {
            try
            {
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@Name", productCategory.Name),
                    new SqlParameter("@Description", productCategory.Description),
                    new SqlParameter("@Status", productCategory.Status),
                };
                var result = db.Database.SqlQuery<ProductCategory>("Sp_ProductCategory_Insert @Name,@Description,@Status", parameters).SingleOrDefault();
                return result.ID;
            }
            catch
            {
                return 0;
            }
        }
        public int Update(ProductCategory productCategory)
        {
            try
            {
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@ID", productCategory.ID),
                    new SqlParameter("@Name", productCategory.Name),
                    new SqlParameter("@Description", productCategory.Description),
                    new SqlParameter("@Status", productCategory.Status),
                };
                int result = db.Database.ExecuteSqlCommand("Sp_ProductCategory_Update @ID,@Name,@Description,@Status", parameters);
                return result;
            }
            catch
            {
                return 0;
            }
        }
        public int UpdateStatus(int? ID)
        {
            try
            {
                int result = db.Database.ExecuteSqlCommand("Sp_ProductCategory_UpdateStatus {0}", ID);
                return result;
            }
            catch
            {
                return 0;
            }
        }
        public int Delete(int ID)
        {
            int result = db.Database.ExecuteSqlCommand("Sp_ProductCategory_Delete {0}", ID);
            return result;
        }
    }
}