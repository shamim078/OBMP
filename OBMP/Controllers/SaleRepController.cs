using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Telerik.OpenAccess.Data.Common;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using OBMPDataModel;

namespace OBMP.Controllers
{
    public class SaleRepController : Controller
    {
        private FluentModel dbContext;

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            this.dbContext = ContextFactory.GetContextPerRequest();
            base.Initialize(requestContext);
        }
        //
        // GET: /SaleRep/

        public ActionResult Manage()
        {
            return View();
        }


        public ActionResult AllSaleReps([DataSourceRequest]DataSourceRequest request)
        {
            var saleRep = dbContext.SalesRepresentatives;

            DataSourceResult result = saleRep.ToDataSourceResult(request);
            return Json(result);

        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(SalesRepresentative newSaleRep)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //throw new Exception("Invalid data");
                    this.dbContext.Add(newSaleRep);
                    this.dbContext.SaveChanges();
                    TempData["Success"] = "true";
                    ModelState.Clear(); //clearing form data
                }
            }
            catch(Exception ex)
            {
                TempData["Success"] = "false";
                TempData["Error"] = ex.ToString();
            }

            return View();

        }

        public ActionResult Update([DataSourceRequest]DataSourceRequest request, OBMPDataModel.SalesRepresentative saleRep)
        {
            if (saleRep.Name.Length < 3)
            {
                ModelState.AddModelError("Name", "Name should be at least three characters long.");
            }


            try
            {

                if (ModelState.IsValid)
                {
                    // 1. Load the original SaleRep from the database.
                    OBMPDataModel.SalesRepresentative originalSaleRep = this.dbContext.SalesRepresentatives.FirstOrDefault(sp => sp.ID == saleRep.ID);

                    // 2. Update with the new data.
                    //originalSaleRep.ID = saleRep.ID;
                    originalSaleRep.Name = saleRep.Name;
                    originalSaleRep.Email = saleRep.Email;
                    originalSaleRep.DateCreated = saleRep.DateCreated;

                    // 3. Save changes.
                    this.dbContext.SaveChanges();
                }
            }

            catch (Exception ex)
            {
                ModelState.AddModelError("Name", ex.ToString());
            }

            // Return the updated SaleRep. Also return any validation errors.
            return Json(new[] { saleRep }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult Mapping()
        {
            return View();
        }


        public ActionResult CustomerMapping([DataSourceRequest]DataSourceRequest request)
        {
            //var customers = dbContext.Customers.Select(c => new Models.CustomerList
            //{
            //    ID = c.ID,
            //    UID = c.UID,
            //    Name = c.Name,
            //    AccountReference = c.AccountReference,
            //    Address = c.Address,
            //    ContactPerson = c.ContactPerson,
            //    ContactDetail = c.ContactDetail
            //});

            IList<Models.CustomerSaleRep> customerSaleRepList = new List<Models.CustomerSaleRep>();
            Models.CustomerSaleRep newCustomerSaleRep; 

            using (IDbConnection oaConnection = dbContext.Connection)
            {
                string SqlQueryString = "SELECT Customer.ID, Customer.UID, Customer.Name, Customer.AccountReference, Customer.ContactPerson, ";
                SqlQueryString= SqlQueryString + " SaleRepCustomer.SalesRepresentativeID FROM Customer INNER JOIN ";
                SqlQueryString= SqlQueryString + " SaleRepCustomer ON Customer.ID = SaleRepCustomer.CustomerID";

                using (IDbCommand oaCommand = oaConnection.CreateCommand())
                {
                    oaCommand.CommandText = SqlQueryString;
                    using (IDataReader reader = oaCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            newCustomerSaleRep = new Models.CustomerSaleRep();

                            newCustomerSaleRep.ID = reader.GetInt64(0);
                            newCustomerSaleRep.UID = reader.GetString(1);
                            newCustomerSaleRep.Name = reader.GetString(2);
                            newCustomerSaleRep.AccountReference = reader.GetString(3);
                            newCustomerSaleRep.ContactPerson = reader.GetString(4);
                            newCustomerSaleRep.SaleRepID = reader.GetInt32(5);
                            

                            //Console.Write(string.Format("Id: {0}", reader.GetInt32(0)));
                            //Console.Write(string.Format("Name: {0}", reader.GetString(1)));
                            //Console.WriteLine();

                            customerSaleRepList.Add(newCustomerSaleRep);
                        }

                        
                    }
                }
            }

            var customers = customerSaleRepList.AsQueryable();


            //DataSourceResult result = customers.ToDataSourceResult(request);
            //return Json(result);

            DataSourceResult result = customers.ToDataSourceResult(request);
            return Json(result);

        }

        public ActionResult GetSaleRep()
        {

            var saleRep = this.dbContext.SalesRepresentatives.OrderBy(sr=>sr.Name);

            return Json(saleRep, JsonRequestBehavior.AllowGet);
        }


        public ActionResult CreateMapping()
        {
            //ViewBag.CategoryID = new SelectList(this.dbContext.Customers, "ID", "Name");
            //ViewBag.SupplierID = new SelectList(this.dbContext.SalesRepresentatives, "ID", "Name");

            return PartialView("_CreateMapping");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMapping(string SaleRep, string customer)
        {
            //ViewBag.CategoryID = new SelectList(this.dbContext.Customers, "ID", "Name");
            //ViewBag.SupplierID = new SelectList(this.dbContext.SalesRepresentatives, "ID", "Name");

            try
            {

                var newSaleRepCustomer = new SaleRepCustomer();
                newSaleRepCustomer.SalesRepresentativeID = Convert.ToInt32(SaleRep);
                newSaleRepCustomer.CustomerID = Convert.ToInt32(customer);
                newSaleRepCustomer.MappedDate = DateTime.Today.Date;

                this.dbContext.Add(newSaleRepCustomer);
                this.dbContext.SaveChanges();

                TempData["Success"] = "true";
                ModelState.Clear(); //clearing form data
            }
            catch (Exception ex)
            {
                TempData["Success"] = "false";
                TempData["Error"] = ex.ToString();
            }

            return View("Mapping");
        }
    }
}
