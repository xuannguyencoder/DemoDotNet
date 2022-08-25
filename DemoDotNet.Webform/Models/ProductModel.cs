using DemoDotNet.Webform.Models.Db;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DemoDotNet.Webform.Models
{
    public class ProductModel
    {
        ConnectDB db = null;
        public ProductModel()
        {
            db = new ConnectDB();
        }
        public List<Product> GetAll()
        {
            string query = "SELECT * FROM Product";
            DataTable dt = db.GetData(query);
            List <Product> products = new List<Product>();
            Product product;
            for (int i =0; i< dt.Rows.Count;i++)
            {
                product = new Product();
                product.ID = int.Parse(dt.Rows[i]["ID"].ToString());
                product.Name = dt.Rows[i]["Name"].ToString();
                product.Price = decimal.Parse(dt.Rows[i]["Price"].ToString());
                product.Description = dt.Rows[i]["Description"].ToString();
                product.Image = dt.Rows[i]["Image"].ToString();
                product.Quantity = int.Parse(dt.Rows[i]["Quantity"].ToString());
                product.Status = dt.Rows[i]["Status"].ToString().Equals("1") ? true : false;
                product.CategoryID = int.Parse(dt.Rows[i]["CategoryID"].ToString());
                products.Add(product);
            }
            return products;
        }
        public Product GetByID(int ID)
        {
            string query = "SELECT * FROM Product WHERE ID = "+ID+" LIMIT 1 ";
            DataTable dt = db.GetData(query);
            if (dt.Rows.Count>0)
            {
                Product product = new Product();
                product.ID = int.Parse(dt.Rows[0]["ID"].ToString());
                product.Name = dt.Rows[0]["Name"].ToString();
                product.Price = decimal.Parse(dt.Rows[0]["Price"].ToString());
                product.Description = dt.Rows[0]["Description"].ToString();
                product.Image = dt.Rows[0]["Image"].ToString();
                product.Quantity = int.Parse(dt.Rows[0]["Quantity"].ToString());
                product.Status = dt.Rows[0]["Status"].ToString().Equals("1") ? true : false;
                product.CategoryID = int.Parse(dt.Rows[0]["CategoryID"].ToString());
                return product;
            }
            return null;
        }

        public int Insert(Product product)
        {
            try
            {
                var parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@CategoryID", product.CategoryID),
                    new MySqlParameter("@Name", product.Name),
                    new MySqlParameter("@Description", product.Description),
                    new MySqlParameter("@Status", product.Status),
                    new MySqlParameter("@Image", product.Image),
                    new MySqlParameter("@Price", product.Price),
                    new MySqlParameter("@Quantity", product.Quantity),
                };

                string query = "INSERT INTO Product(Name,CategoryID,Image,Price,Quantity,Description,Status) VALUES(@Name,@CategoryID,@Image,@Price,@Quantity,@Description,@Status)";
                return db.Execute(query, parameters);
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
                if (!string.IsNullOrEmpty(product.Image))
                    model.Image = product.Image;
                model.Price = product.Price;
                model.Quantity = product.Quantity;

                var parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@ID", model.ID),
                    new MySqlParameter("@CategoryID", model.CategoryID),
                    new MySqlParameter("@Name", model.Name),
                    new MySqlParameter("@Description", model.Description),
                    new MySqlParameter("@Status", model.Status),
                    new MySqlParameter("@Image", model.Image),
                    new MySqlParameter("@Price", model.Price),
                    new MySqlParameter("@Quantity", model.Quantity),
                };

                string query = "UPDATE Product SET Name = @Name, CategoryID=@CategoryID, Image=@Image,Price=@Price, Quantity = @Quantity,Description=@Description, Status =@Status WHERE ID = @ID";
                return db.Execute(query, parameters);
            }
            catch
            {
                return 0;
            }
        }
        public int Delete(int ID)
        {
            try
            {
                string query = "DELETE FROM Product WHERE ID =@ID";
                var parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@ID", ID)
                };
                return db.Execute(query, parameters);
            }
            catch
            {
                return 0;
            }
            
        }
    }
}