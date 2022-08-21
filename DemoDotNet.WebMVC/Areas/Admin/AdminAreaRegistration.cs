﻿using System.Web.Mvc;

namespace DemoDotNet.WebMVC.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            //ProductCategoryController
            context.MapRoute(
                "ListProductCategory",
                "admin/danh-muc-san-pham",
                new { controller = "ProductCategory", action = "Index" }
            );
            context.MapRoute(
                "CreateProductCategory",
                "admin/danh-muc-san-pham/them",
                new { controller = "ProductCategory", action = "Create" }
            );
            context.MapRoute(
                "EditProductCategory",
                "admin/danh-muc-san-pham/chinh-sua/{ID}",
                new { controller = "ProductCategory", action = "Edit" }
            );
            //Default
            context.MapRoute(
                "Admin_Home",
                "admin/",
                new { controller = "Home", action = "Index" }
            );
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}