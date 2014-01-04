using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OBMP.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace OBMP.Controllers
{
    public class OrderController : Controller
    {
        readonly Data.northwindEntities _context = new Data.northwindEntities();

        //private EntitiesModel1 dbContext;

        //protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        //{
        //    this.dbContext = ORMData.ContextFactory.GetContextPerRequest();
        //    base.Initialize(requestContext);
        //}

        //
        // GET: /Order/All

        public ActionResult All()
        {
            return View();
        }


        //
        // GET: /Order/Accepted

        public ActionResult Accepted()
        {
            return View();
        }

        //
        // GET: /Order/Confirmed

        public ActionResult Confirmed()
        {
            return View();
        }

        //
        // GET: /Order/Rejected

        public ActionResult Rejected()
        {
            return View();
        }

        //
        // GET: /Order/Pending

        public ActionResult Pending()
        {
            return View();
        }

        // parse the incoming request from Kendo UI into a DataSourceRequest
        public JsonResult GetAllProducts([DataSourceRequest]DataSourceRequest request)
        {

            // LINQ query to select products and map to model objects
            var products = _context.Products.Select(p => new Models.Product
            {
                Id = p.ProductID,
                Name = p.ProductName,
                UnitsInStock = p.UnitsInStock,
                UnitPrice = p.UnitPrice,
                Discontinued = p.Discontinued,
                Supplier = new Models.Supplier
                {
                    Id = p.Supplier.SupplierID,
                    Name = p.Supplier.CompanyName
                },
                Category = new Models.Category
                {
                    Id = p.Category.CategoryID,
                    Name = p.Category.CategoryName
                }
            });

            // convert to a DataSourceResponse and send back as JSON
            //return this.Json(products.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            return this.Json(products.ToDataSourceResult(request));

        }

        // parse the incoming request from Kendo UI into a DataSourceRequest
        public JsonResult GetAcceptedProducts([DataSourceRequest]DataSourceRequest request)
        {

            // LINQ query to select products and map to model objects
            var products = _context.Products.Select(p => new Models.Product
            {
                Id = p.ProductID,
                Name = p.ProductName,
                UnitsInStock = p.UnitsInStock,
                UnitPrice = p.UnitPrice,
                Discontinued = p.Discontinued,
                Supplier = new Models.Supplier
                {
                    Id = p.Supplier.SupplierID,
                    Name = p.Supplier.CompanyName
                },
                Category = new Models.Category
                {
                    Id = p.Category.CategoryID,
                    Name = p.Category.CategoryName
                }
            });

            // convert to a DataSourceResponse and send back as JSON
            //return this.Json(products.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            return this.Json(products.ToDataSourceResult(request));

        }


        // parse the incoming request from Kendo UI into a DataSourceRequest
        public JsonResult GetConfirmedProducts([DataSourceRequest]DataSourceRequest request)
        {

            // LINQ query to select products and map to model objects
            var products = _context.Products.Select(p => new Models.Product
            {
                Id = p.ProductID,
                Name = p.ProductName,
                UnitsInStock = p.UnitsInStock,
                UnitPrice = p.UnitPrice,
                Discontinued = p.Discontinued,
                Supplier = new Models.Supplier
                {
                    Id = p.Supplier.SupplierID,
                    Name = p.Supplier.CompanyName
                },
                Category = new Models.Category
                {
                    Id = p.Category.CategoryID,
                    Name = p.Category.CategoryName
                }
            });

            // convert to a DataSourceResponse and send back as JSON
            //return this.Json(products.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            return this.Json(products.ToDataSourceResult(request));

        }


        // parse the incoming request from Kendo UI into a DataSourceRequest
        public JsonResult GetRejectedProducts([DataSourceRequest]DataSourceRequest request)
        {

            // LINQ query to select products and map to model objects
            var products = _context.Products.Select(p => new Models.Product
            {
                Id = p.ProductID,
                Name = p.ProductName,
                UnitsInStock = p.UnitsInStock,
                UnitPrice = p.UnitPrice,
                Discontinued = p.Discontinued,
                Supplier = new Models.Supplier
                {
                    Id = p.Supplier.SupplierID,
                    Name = p.Supplier.CompanyName
                },
                Category = new Models.Category
                {
                    Id = p.Category.CategoryID,
                    Name = p.Category.CategoryName
                }
            });

            // convert to a DataSourceResponse and send back as JSON
            //return this.Json(products.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            return this.Json(products.ToDataSourceResult(request));

        }


        // parse the incoming request from Kendo UI into a DataSourceRequest
        public JsonResult GetPendingProducts([DataSourceRequest]DataSourceRequest request)
        {

            // LINQ query to select products and map to model objects
            var products = _context.Products.Select(p => new Models.Product
            {
                Id = p.ProductID,
                Name = p.ProductName,
                UnitsInStock = p.UnitsInStock,
                UnitPrice = p.UnitPrice,
                Discontinued = p.Discontinued,
                Supplier = new Models.Supplier
                {
                    Id = p.Supplier.SupplierID,
                    Name = p.Supplier.CompanyName
                },
                Category = new Models.Category
                {
                    Id = p.Category.CategoryID,
                    Name = p.Category.CategoryName
                }
            });

            // convert to a DataSourceResponse and send back as JSON
            //return this.Json(products.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            return this.Json(products.ToDataSourceResult(request));

        }

        // parse the incoming request from Kendo UI into a DataSourceRequest
        public JsonResult GetAllOrders([DataSourceRequest]DataSourceRequest request)
        {

            var orders = _context.Orders.Select(o => new Models.OrderViewModel
            {
                Id=o.OrderID,
                CustomerId=o.Customer.CustomerID,
                CustomerName=o.Customer.CompanyName,
                OrderDate=(DateTime)o.OrderDate,
                RequiredDate = (DateTime)o.RequiredDate,
                Status = 1
            });

            return this.Json(orders.ToDataSourceResult(request));

        }


    }
}
