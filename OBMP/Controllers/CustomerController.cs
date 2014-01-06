using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using OBMP.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using OBMPDataModel;

namespace OBMP.Controllers
{
    //[Authorize(Roles = "Customer")]
    public class CustomerController : Controller
    {

        //readonly Data.northwindEntities _context = new Data.northwindEntities();


        private FluentModel dbContext;

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            this.dbContext = ContextFactory.GetContextPerRequest();
            base.Initialize(requestContext);
        }

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

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Customer newCustomer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //throw new Exception("Invalid data");
                    this.dbContext.Add(newCustomer);
                    this.dbContext.SaveChanges();
                    TempData["Success"] = "true";
                    ModelState.Clear(); //clearing form data
                }
            }
            catch(Exception ex)
            {
                TempData["Success"] = "false";
                TempData["ErrorMessage"] = ex.ToString();
            }

            return View();

        }

        public ActionResult Edit()
        {
            return View();
        }


        public ActionResult AllCustomers([DataSourceRequest]DataSourceRequest request)
        {
            var customers = dbContext.Customers.Select(c => new Models.CustomerList
            {
                ID = c.ID,
                UID= c.UID,
                Name = c.Name,
                AccountReference=c.AccountReference,
                Address = c.Address,
                ContactPerson= c.ContactPerson,
                ContactDetail=c.ContactDetail 
            });


            DataSourceResult result = customers.ToDataSourceResult(request);
            return Json(result);

        }


        public ActionResult Update([DataSourceRequest]DataSourceRequest request, Customer customer)
        {
            if (customer.Name.Length < 3)
            {
                ModelState.AddModelError("Name", "Partner Name should be at least three characters long.");
            }


            try
            {

                if (ModelState.IsValid)
                {
                    // 1. Load the original customer from the database.
                    Customer originalCustomer = this.dbContext.Customers.FirstOrDefault(c => c.ID == customer.ID);

                    // 2. Update with the new data.
                    originalCustomer.ID = customer.ID;
                    originalCustomer.UID = customer.UID;
                    originalCustomer.Name = customer.Name;
                    originalCustomer.AccountReference = customer.AccountReference;
                    originalCustomer.Address = customer.Address;
                    originalCustomer.ContactPerson = customer.ContactPerson;
                    originalCustomer.ContactDetail = customer.ContactDetail;

                    // 3. Save changes.
                    this.dbContext.SaveChanges();
                }
            }

            catch (Exception ex)
            {
                ModelState.AddModelError("Name", ex.ToString());
            }

            // Return the updated product. Also return any validation errors.
            return Json(new[] { customer }.ToDataSourceResult(request, ModelState));
        }

        //// parse the incoming request from Kendo UI into a DataSourceRequest
        //public JsonResult GetProducts([DataSourceRequest]DataSourceRequest request)
        //{

        //    // LINQ query to select products and map to model objects
        //    var products = _context.Products.Select(p => new Models.Product
        //    {
        //        Id = p.ProductID,
        //        Name = p.ProductName,
        //        UnitsInStock = p.UnitsInStock,
        //        UnitPrice = p.UnitPrice,
        //        Discontinued = p.Discontinued,
        //        Supplier = new Models.Supplier
        //        {
        //            Id = p.Supplier.SupplierID,
        //            Name = p.Supplier.CompanyName
        //        },
        //        Category = new Models.Category
        //        {
        //            Id = p.Category.CategoryID,
        //            Name = p.Category.CategoryName
        //        }
        //    });

        //    // convert to a DataSourceResponse and send back as JSON
        //    //return this.Json(products.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        //    return this.Json(products.ToDataSourceResult(request));

        //}
    }
}
