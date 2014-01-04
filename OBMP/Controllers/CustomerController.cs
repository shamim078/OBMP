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
    //[Authorize(Roles = "Customer")]
    public class CustomerController : Controller
    {

        readonly Data.northwindEntities _context = new Data.northwindEntities();

        //
        // GET: /Customer/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Manage()
        {
            return View();
        }



        // parse the incoming request from Kendo UI into a DataSourceRequest
        public JsonResult GetProducts([DataSourceRequest]DataSourceRequest request)
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
    }
}
