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

        public ActionResult GetCustomers()
        {

            var saleRep = this.dbContext.Customers.OrderBy(c => c.Name);

            return Json(saleRep, JsonRequestBehavior.AllowGet);
        }
    }
}
