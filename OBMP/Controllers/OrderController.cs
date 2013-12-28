using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OBMP.Controllers
{
    public class OrderController : Controller
    {
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

    }
}
