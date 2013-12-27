using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OBMP.Controllers
{
   // [Authorize(Roles = "Optus")]
    public class OptusController : Controller
    {
        //
        // GET: /Optus/

        public ActionResult Index()
        {
            return View();
        }

    }
}
