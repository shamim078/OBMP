using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OBMP.Controllers
{
    //[Authorize(Roles = "Partner")]
    public class PartnerController : Controller
    {
        //
        // GET: /Partner/

        public ActionResult Index()
        {
            return View();
        }

    }
}
