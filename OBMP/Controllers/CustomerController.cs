﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OBMP.Controllers
{
    //[Authorize(Roles = "Customer")]
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/

        public ActionResult Index()
        {
            return View();
        }


        //
        // GET: /Customer/Orders

        public ActionResult Order()
        {
            return View();
        }
    }
}
