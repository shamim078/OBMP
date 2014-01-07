using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OBMPDataModel;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace OBMP.Controllers
{
    public class HomeController : Controller
    {

        private FluentModel dbContext;

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            this.dbContext = ContextFactory.GetContextPerRequest();
            base.Initialize(requestContext);
        }


        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }
        
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

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

    }
}
