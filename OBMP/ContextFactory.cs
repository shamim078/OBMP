
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OBMP
{
    public class ContextFactory
    {
        private static readonly string ContextKey = typeof(OBMPDataModel.FluentModel).FullName;

        public static OBMPDataModel.FluentModel GetContextPerRequest()
        {
            HttpContext httpContext = HttpContext.Current;

            if (httpContext == null)
            {
                return new OBMPDataModel.FluentModel();
            }
            else
            {
                OBMPDataModel.FluentModel context = httpContext.Items[ContextKey] as OBMPDataModel.FluentModel;
                if (context == null)
                {
                    context = new OBMPDataModel.FluentModel();
                    httpContext.Items[ContextKey] = context;
                }

                return context;
            }

        }

        public static void Dispose()
        {
            HttpContext httpContext = HttpContext.Current;
            if (httpContext != null)
            {
                OBMPDataModel.FluentModel context = httpContext.Items[ContextKey] as OBMPDataModel.FluentModel;
                if (context != null)
                {
                    context.Dispose();
                    httpContext.Items[ContextKey] = null;
                }
            }
        }
    }
}