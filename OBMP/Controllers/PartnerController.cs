using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using OBMPDataModel;

namespace OBMP.Controllers
{
    //[Authorize(Roles = "Partner")]
    public class PartnerController : Controller
    {
        private FluentModel dbContext;

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            this.dbContext = ContextFactory.GetContextPerRequest();
            base.Initialize(requestContext);
        }

        //
        // GET: /Partner/

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
        public ActionResult Add(Partner newPartner)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //throw new Exception("Invalid data");
                    this.dbContext.Add(newPartner);
                    this.dbContext.SaveChanges();
                    TempData["Success"] = "true";
                    ModelState.Clear(); //clearing form data
                }
            }
            catch
            {
                TempData["Success"] = "false";
            }

            return View();

        }

        public ActionResult Edit()
        {
            return View();
        }


        public ActionResult AllPartners([DataSourceRequest]DataSourceRequest request)
        {
            var partners = dbContext.Partners.Select(p => new Models.PartnerList
            {
                ID = p.ID,
                Name = p.Name,
                MSAReference = p.MSAReference,
                Address = p.Address,
                PartnerType = p.PartnerType,
                PartnerShare = (int)p.PartnerShare,
                PrimaryContact = p.PrimaryContact,
                DateRegistered = (DateTime)p.DateRegistered
            });


            DataSourceResult result = partners.ToDataSourceResult(request);
            return Json(result);

        }


        public ActionResult Update([DataSourceRequest]DataSourceRequest request, Partner partner)
        {
            if (partner.Name.Length < 3)
            {
                ModelState.AddModelError("Name", "Partner Name should be at least three characters long.");
            }


            try
            {

                if (ModelState.IsValid)
                {
                    // 1. Load the original partner from the database.
                    Partner originalPartner = this.dbContext.Partners.FirstOrDefault(p => p.ID == partner.ID);

                    // 2. Update with the new data.
                    originalPartner.ID = partner.ID;
                    originalPartner.Name = partner.Name;
                    originalPartner.MSAReference = partner.MSAReference;
                    originalPartner.Address = partner.Address;
                    originalPartner.PartnerType = partner.PartnerType;
                    originalPartner.PartnerShare = partner.PartnerShare;
                    originalPartner.DateRegistered = partner.DateRegistered;
                    originalPartner.PrimaryContact = partner.PrimaryContact;


                    // 3. Save changes.
                    this.dbContext.SaveChanges();
                }
            }

            catch (Exception ex)
            {
                ModelState.AddModelError("Name", ex.ToString());
            }

            // Return the updated product. Also return any validation errors.
            return Json(new[] { partner }.ToDataSourceResult(request, ModelState));
        }

    }
}
