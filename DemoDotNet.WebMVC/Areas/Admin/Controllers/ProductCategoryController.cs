using DemoDotNet.WebMVC.Models;
using DemoDotNet.WebMVC.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoDotNet.WebMVC.Areas.Admin.Controllers
{
    public class ProductCategoryController : Controller
    {
        // GET: Admin/ProductCategory
        ProductCategoryModel cateModel = new ProductCategoryModel();
        public ActionResult Index()
        {
            var model = cateModel.GetAll();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection form, ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                int result = cateModel.Insert(productCategory);
                if (result > 0)
                {
                    TempData["Message"] = "Thêm danh mục thành công";
                    TempData["Status"] = "success";
                    if (form["btnAdd"] != null)
                        return RedirectToAction("Index");
                    else
                        return RedirectToAction("Create");
                }
            }
            return View(productCategory);
        }
        public ActionResult Edit(int? ID)
        {
            if (ID == null)
            {
                return View("_Error400");
            }
            var productCate = cateModel.GetByID(ID);
            if (productCate == null)
            {
                return View("_Error404");
            }
            return View(productCate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                int result = cateModel.Update(productCategory);
                if (result>0)
                {
                    TempData["Message"] = "Cập nhật danh mục thành công";
                    TempData["Status"] = "success";
                    return RedirectToAction("Index");
                }
            }
            return View(productCategory);
        }

        public ActionResult Delete(int? ID)
        {
            if (ID == null)
            {
                return View("_Error400");
            }
            var productCate = cateModel.GetByID(ID);
            if (productCate == null)
            {
                return View("_Error404");
            }
            var result = cateModel.Delete(productCate.ID);
            if (result>0)
            {
                TempData["Message"] = "Xóa danh mục thành công";
                TempData["Status"] = "success";
            }
            return RedirectToAction("Index");
        }
        public ActionResult UpdateStatus(int? ID)
        {
            if (ID == null)
            {
                return View("_Error400");
            }
            int result = cateModel.UpdateStatus(ID);
            if (result>0)
            {
                TempData["Message"] = "Cập nhật trạng thái thành công";
                TempData["Status"] = "success";
                return RedirectToAction("Index");
            }
            else
                return View("_Error404");
        }
    }
}