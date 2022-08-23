using DemoDotNet.WebMVC.Models;
using DemoDotNet.WebMVC.Models.EF;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace DemoDotNet.WebMVC.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private ProductModel productModel = new ProductModel();
        private ProductCategoryModel cateModel = new ProductCategoryModel();

        public ActionResult Index()
        {
            return View(productModel.GetAll());
        }

        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(cateModel.GetAll(), "ID", "Name");
            return View();
        }

        [HttpPost]
        public JsonResult Create(FormCollection form)
        {
            HttpFileCollectionBase files = Request.Files;
            HttpPostedFileBase file = files[0];
            string filename = Path.GetFileName(file.FileName);
            string _filename = DateTime.Now.ToString("yymmssfff") + "_" + filename;
            try
            {
                Product product = new Product();
                product.Name = form["Name"];
                product.Description = string.IsNullOrEmpty(form["Description"]) ? "" : form["Description"];
                product.Price = string.IsNullOrEmpty(form["Price"]) ? 0 : decimal.Parse(form["Price"]);
                product.Status = bool.Parse(form["Status"]);

                product.Image = (file == null) ? "" : _filename;
                product.CategoryID = string.IsNullOrEmpty(form["CategoryID"]) ? 0 : int.Parse(form["CategoryID"]);
                int result = productModel.Insert(product);
                if (result > 0)
                {
                    TempData["Message"] = "Thêm sản phẩm thành công";
                    TempData["Status"] = "success";
                    if (file != null)
                    {
                        string path = Path.Combine(Server.MapPath("~/Assets/uploads/images/products/"), _filename);
                        file.SaveAs(path);
                    }
                    return Json(new { status = true }, JsonRequestBehavior.AllowGet);
                }
            }
            catch
            {
                return Json(new { status = false }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { status = false }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(int? ID)
        {
            if (ID == null)
            {
                return View("_Error400");
            }
            var product = productModel.GetByID(ID);
            if (product == null)
            {
                return View("_Error404");
            }
            ViewBag.CategoryID = new SelectList(cateModel.GetAll(), "ID", "Name");
            TempData["ImageName"] = product.Image;
            return View(product);
        }

        [HttpPost]
        public JsonResult Edit(FormCollection form)
        {
            HttpFileCollectionBase files = Request.Files;
            HttpPostedFileBase file =null;
            string _filename = "";
            if (files.Count>0)
            {
                file = files[0];
                string filename = Path.GetFileName(file.FileName);
                _filename = DateTime.Now.ToString("yymmssfff") + "_" + filename;
            }

            try
            {
                Product product = new Product();
                product.ID = string.IsNullOrEmpty(form["ID"]) ? 0 : int.Parse(form["ID"]);
                product.Name = form["Name"];
                product.Description = string.IsNullOrEmpty(form["Description"]) ? "" : form["Description"];
                product.Price = string.IsNullOrEmpty(form["Price"]) ? 0 : decimal.Parse(form["Price"]);
                product.Status = bool.Parse(form["Status"]);

                product.Image = (file == null) ? "" : _filename;
                product.CategoryID = string.IsNullOrEmpty(form["CategoryID"]) ? 0 : int.Parse(form["CategoryID"]);
                int result = productModel.Update(product);
                if (result > 0)
                {
                    TempData["Message"] = "Cập nhật sản phẩm thành công";
                    TempData["Status"] = "success";
                    if (file != null)
                    {
                        string path = Path.Combine(Server.MapPath("~/Assets/uploads/images/products/"), _filename);
                        file.SaveAs(path);
                        string oldImgPath = Request.MapPath("~/Assets/uploads/images/products/" + TempData["ImageName"]);
                        if (System.IO.File.Exists(oldImgPath))
                        {
                            System.IO.File.Delete(oldImgPath);
                        }
                    }
                    return Json(new { status = true }, JsonRequestBehavior.AllowGet);
                }
            }
            catch
            {
                return Json(new { status = false }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { status = false }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Delete(int ID)
        {
            var product = productModel.GetByID(ID);
            if (product == null)
            {
                return Json(new { status = false }, JsonRequestBehavior.AllowGet);
            }
            var result = productModel.Delete(product.ID);
            if (result > 0)
            {
                TempData["Message"] = "Xóa sản phẩm thành công";
                TempData["Status"] = "success";
            }
            else
            {
                TempData["Message"] = "Xóa thất bại";
                TempData["Status"] = "error";
            }
            return Json(JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult UpdateStatus(int ID)
        {
            int result = productModel.UpdateStatus(ID);
            if (result > 0)
            {
                TempData["Message"] = "Cập nhật trạng thái thành công";
                TempData["Status"] = "success";
            }
            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}