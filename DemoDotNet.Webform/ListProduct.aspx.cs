using DemoDotNet.Webform.Models;
using DemoDotNet.Webform.Models.Db;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoDotNet.Webform
{
    public partial class ListProduct : System.Web.UI.Page
    {
        ProductModel productModel = new ProductModel();

        protected void Page_Load(object sender, EventArgs e)
        { 
            if (!IsPostBack)
            {
                LoadProduct();
                LoadDDLCategory();
            }
        }
        public void LoadProduct()
        {
            var products = productModel.GetAll();
            RepeaterList.DataSource = products;
            RepeaterList.DataBind();
        }
        public void LoadDDLCategory()
        {
            ProductCategoryModel cateModel = new ProductCategoryModel();
            DDLCategory.DataSource = cateModel.GetAll();
            DDLCategory.DataTextField = "Name";
            DDLCategory.DataValueField = "ID";
            DDLCategory.DataBind();
        }
        protected void OnSelect(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            Label lbProductID = (Label)item.FindControl("lbID");
            var product = productModel.GetByID(int.Parse(lbProductID.Text));
            if (product!=null)
            {
                DDLCategory.SelectedValue = product.CategoryID.ToString();
                txtDescription.Text = product.Description;
                txtName.Text = product.Name;
                txtPrice.Text = product.Price.ToString();
                txtQuantity.Text = product.Quantity.ToString();
                txtID.Value = product.ID.ToString();
                cboxStatus.Checked = product.Status;
                btnAdd.Text = "Cập nhật";
            }
        }
        protected void OnDelete(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            Label lbProductID = (Label)item.FindControl("lbID");
            var product = productModel.GetByID(int.Parse(lbProductID.Text));
            if (product != null)
            {
                if (productModel.Delete(product.ID)>0)
                {
                    string oldImgPath = Request.MapPath("~/Images/" + product.Image);
                    if (System.IO.File.Exists(oldImgPath))
                    {
                        System.IO.File.Delete(oldImgPath);
                    }
                    Session["Message"] = "Xóa thành công";
                    Session["Status"] = "success";
                    LoadProduct();
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.Name = txtName.Text;
            product.Description = txtDescription.Text;
            product.Quantity = int.Parse(txtQuantity.Text);
            product.Price = decimal.Parse(txtPrice.Text);
            product.CategoryID = int.Parse(DDLCategory.SelectedValue);
            product.Status =cboxStatus.Checked;
            product.Image = "";
            string fileName ="";
            if (!string.IsNullOrEmpty(FileUpload.FileName))
            {
                fileName = DateTime.Now.ToString("ddMMyyyy_hhmmss_tt_") + FileUpload.FileName;
                string expand = Path.GetExtension(fileName);
                if (expand.ToLower() == ".png" || expand.ToLower() == ".jpg" || expand.ToLower() == ".jpeg")
                {
                    product.Image = fileName;
                }
            }
            
            if (btnAdd.Text.Equals("Thêm"))
            {
                if (productModel.Insert(product) > 0)
                {
                    string filePath = MapPath("~/Images/" + fileName);
                    if (!string.IsNullOrEmpty(FileUpload.FileName)){
                        FileUpload.SaveAs(filePath);
                    }
                    Session["Message"] = "Thêm thành công";
                    Session["Status"] = "success";
                    LoadProduct();
                }
            }
            else if(btnAdd.Text.Equals("Cập nhật"))
            {
                if (!string.IsNullOrEmpty(txtID.Value))
                {
                    product.ID = int.Parse(txtID.Value);
                    Product pro = productModel.GetByID(product.ID);
                    string OldImage = pro.Image;
                    if (productModel.Update(product) > 0)
                    {
                        string filePath = MapPath("~/Images/" + fileName);
                        if (!string.IsNullOrEmpty(FileUpload.FileName))
                        {
                            
                            FileUpload.SaveAs(filePath);
                            string oldImgPath = Request.MapPath("~/Images/"+ OldImage);
                            if (System.IO.File.Exists(oldImgPath))
                            {
                                System.IO.File.Delete(oldImgPath);
                            }
                        }
                        Session["Message"] = "Cập nhật thành công";
                        Session["Status"] = "success";
                        LoadProduct();
                        ClearForm();
                        btnAdd.Text = "Thêm";
                    }
                }
            }
        }
        public void ClearForm()
        {
            txtID.Value = "";
            txtName.Text = "";
            txtPrice.Text = "";
            txtQuantity.Text = "";
            txtDescription.Text = "";
        }
    }
}