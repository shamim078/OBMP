using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;
using OBMP.Models;

namespace OBMP.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class InitializeSimpleMembershipAttribute : ActionFilterAttribute
    {
        private static SimpleMembershipInitializer _initializer;
        private static object _initializerLock = new object();
        private static bool _isInitialized;

        //public override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    // Ensure ASP.NET Simple Membership is initialized only once per app start
        //    LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
        //}

        private class SimpleMembershipInitializer
        {
            public SimpleMembershipInitializer()
            {
                Database.SetInitializer<UsersContext>(null);

                try
                {
                    using (var context = new UsersContext())
                    {
                        if (!context.Database.Exists())
                        {
                            // Create the SimpleMembership database without Entity Framework migration schema
                            ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                        }
                    }

                    WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);

                    //seeding the role provider
                    var roles = (SimpleRoleProvider)Roles.Provider;
                    var membership = (SimpleMembershipProvider)Membership.Provider;


                    if (!roles.RoleExists("Optus"))
                        roles.CreateRole("Optus");

                    if (!roles.RoleExists("Partner"))
                        roles.CreateRole("Partner");

                    if (!roles.RoleExists("Customer"))
                        roles.CreateRole("Customer");

                    if (membership.GetUser("customer", false) == null)
                    {
                        membership.CreateUserAndAccount("customer", "customer123");
                    }

                    if (membership.GetUser("partner", false) == null)
                    {
                        membership.CreateUserAndAccount("partner", "partner123");
                    }

                    if (membership.GetUser("optus", false) == null)
                    {
                        membership.CreateUserAndAccount("optus", "optus123");
                    }

                    roles.AddUsersToRoles(new[] { "optus" }, new[] { "Optus" });
                    roles.AddUsersToRoles(new[] { "customer" }, new[] { "Customer" });
                    roles.AddUsersToRoles(new[] { "partner" }, new[] { "Partner" });

                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
                }
            }
        }
    }
}
