﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OBMPDataModel;

namespace OBMP.Controllers
{
    public class CategoryController : Controller
    {
        private FluentModel dbContext;

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            this.dbContext = ContextFactory.GetContextPerRequest();
            base.Initialize(requestContext);
        }
     
   

    }
}
