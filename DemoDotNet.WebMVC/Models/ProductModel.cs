using DemoDotNet.WebMVC.Models.EF;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DemoDotNet.WebMVC.Models
{
    public class ProductModel
    {
        DemoDotNetDbContext db = null;
        public ProductModel()
        {
            db = new DemoDotNetDbContext();
        }
        public List<Product> GetAll()
        {
            var list = db.Database.SqlQuery<Product>("SELECT * FROM Product").ToList();
            return list;
        }
        public Product GetByID(int? ID)
        {
            SqlParameter sqlParameter = new SqlParameter("@ID", ID);
            var result = db.Database.SqlQuery<Product>("SELECT * FROM Product where ID = @ID", sqlParameter).SingleOrDefault();
            return result;
        }

        public int Insert(Product product)
        {
            try
            {
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@CategoryID", product.CategoryID),
                    new SqlParameter("@Name", product.Name),
                    new SqlParameter("@Description", product.Description),
                    new SqlParameter("@Status", product.Status),
                    new SqlParameter("@Image", product.Image),
                    new SqlParameter("@Price", product.Price),
                };

                string query = "INSERT INTO Product(Name,CategoryID,Image,Price,Description,Status) VALUES(@Name,@CategoryID,@Image,@Price,@Description,@Status)";
                int result = db.Database.ExecuteSqlCommand(query, parameters);
                return result;
            }
            catch
            {
                return 0;
            }
        }
        public int Update(Product product)
        {
            try
            {
                var model = GetByID(product.ID);
                model.Name = product.Name;
                model.Description = product.Description;
                model.Status = product.Status;
                if(product.Image != "")
                    model.Image = product.Image;
                model.Price = product.Price;

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@ID", model.ID),
                    new SqlParameter("@CategoryID", model.CategoryID),
                    new SqlParameter("@Name", model.Name),
                    new SqlParameter("@Description", model.Description),
                    new SqlParameter("@Status", model.Status),
                    new SqlParameter("@Image", model.Image),
                    new SqlParameter("@Price", model.Price),
                };
                string query = "UPDATE Product SET Name = @Name, CategoryID=@CategoryID, Image=@Image,Price=@Price,Description=@Description, Status =@Status WHERE ID = @ID";
                int result = db.Database.ExecuteSqlCommand(query, parameters);
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
                var model = GetByID(ID);
                bool status = model.Status == true ? false : true;
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@ID", ID),
                    new SqlParameter("@Status", status),
                };
                int result = db.Database.ExecuteSqlCommand("UPDATE Product SET Status = @Status WHERE ID =@ID", parameters);
                return result;
            }
            catch
            {
                return 0;
            }
        }
        public int Delete(int ID)
        {
            SqlParameter parameter = new SqlParameter("@ID", ID);
            int result = db.Database.ExecuteSqlCommand("DELETE Product WHERE ID =@ID", parameter);
            return result;
        }
    }
}