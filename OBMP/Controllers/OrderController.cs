using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Common;
using Telerik.OpenAccess.Data.Common;
using System.Web;
using System.Web.Mvc;
using OBMP.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using OBMPDataModel;

namespace OBMP.Controllers
{
    public class OrderController : Controller
    {
        readonly Data.northwindEntities _context = new Data.northwindEntities();

        private FluentModel dbContext;

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            this.dbContext = ContextFactory.GetContextPerRequest();
            base.Initialize(requestContext);
        }

        public ActionResult Manage()
        {
            return View();
        }

        public ActionResult Create()
        {

            ViewData["products"] = this.dbContext.Products
                         .Select(p => new ProductList 
                         {
                             ID = p.ID,
                             Name = p.Name 
                         })
                         .OrderBy(p => p.Name);

            return View(new OrderModel
                            {
                                OrderID = 0,
                                OrderDetailLists = new List<OrderDetailList> 
                                {
                                    new OrderDetailList 
                                    {
                                        ProductID=1,
                                        UnitPrice=10,
                                        OrderQuantity=1
                                    }
                                    
                                }
                            }
                );
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create( Models.OrderModel orderModel)  //FormCollection fc
        {
            //FormCollection fc = Request.for;

            try
            {
                var newOrder = new OBMPDataModel.Order();

                //setting today's date as default order date
                var OrderDate = DateTime.Today; 

                newOrder.OrderDate = OrderDate;
                newOrder.DueDate = orderModel.DueDate;
                newOrder.CustomerID = orderModel.CustomerID;
                newOrder.SalesPersonID = (int)orderModel.SalesRepID;
                newOrder.Status = 1;
                
                this.dbContext.Add(newOrder);
                
                foreach( Models.OrderDetailList item in orderModel.OrderDetailLists)
                {
                    var newOrderDetailList = new OBMPDataModel.OrderDetail();

                    newOrderDetailList.ProductID = item.ProductID;
                    newOrderDetailList.UnitPrice = (int)item.UnitPrice;
                    newOrderDetailList.OrderQuantity = item.OrderQuantity;
                    newOrderDetailList.CustomerID = orderModel.CustomerID;

                    newOrderDetailList.Order = newOrder; //mapping to parent order

                    this.dbContext.Add(newOrderDetailList);
                }
                
                
                this.dbContext.SaveChanges();
                TempData["Success"] = "true";

                ModelState.Clear(); //clearing form data

            }
            catch (Exception ex)
            {
                TempData["Success"] = "false";
                TempData["ErrorMessage"] = ex.ToString();
            }

            //return View();



            ViewData["products"] = this.dbContext.Products
                         .Select(p => new ProductList
                         {
                             ID = p.ID,
                             Name = p.Name
                         })
                         .OrderBy(p => p.Name);

            return View(new OrderModel
            {
                OrderID = 0,
                OrderDetailLists = new List<OrderDetailList> 
                                {
                                    new OrderDetailList 
                                    {
                                        ProductID=1,
                                        UnitPrice=10,
                                        OrderQuantity=1
                                    }
                                    
                                }
            }
                );

        }


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

        // parse the incoming request from Kendo UI into a DataSourceRequest
        public JsonResult GetAllProducts([DataSourceRequest]DataSourceRequest request)
        {

            // LINQ query to select products and map to model objects
            var products = _context.Products.Select(p => new Models.Product
            {
                Id = p.ProductID,
                Name = p.ProductName,
                UnitsInStock = p.UnitsInStock,
                UnitPrice = p.UnitPrice,
                Discontinued = p.Discontinued,
                Supplier = new Models.Supplier
                {
                    Id = p.Supplier.SupplierID,
                    Name = p.Supplier.CompanyName
                },
                Category = new Models.Category
                {
                    Id = p.Category.CategoryID,
                    Name = p.Category.CategoryName
                }
            });

            // convert to a DataSourceResponse and send back as JSON
            //return this.Json(products.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            return this.Json(products.ToDataSourceResult(request));

        }

        // parse the incoming request from Kendo UI into a DataSourceRequest
        public JsonResult GetAcceptedProducts([DataSourceRequest]DataSourceRequest request)
        {

            // LINQ query to select products and map to model objects
            var products = _context.Products.Select(p => new Models.Product
            {
                Id = p.ProductID,
                Name = p.ProductName,
                UnitsInStock = p.UnitsInStock,
                UnitPrice = p.UnitPrice,
                Discontinued = p.Discontinued,
                Supplier = new Models.Supplier
                {
                    Id = p.Supplier.SupplierID,
                    Name = p.Supplier.CompanyName
                },
                Category = new Models.Category
                {
                    Id = p.Category.CategoryID,
                    Name = p.Category.CategoryName
                }
            });

            // convert to a DataSourceResponse and send back as JSON
            //return this.Json(products.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            return this.Json(products.ToDataSourceResult(request));

        }


        // parse the incoming request from Kendo UI into a DataSourceRequest
        public JsonResult GetConfirmedProducts([DataSourceRequest]DataSourceRequest request)
        {

            // LINQ query to select products and map to model objects
            var products = _context.Products.Select(p => new Models.Product
            {
                Id = p.ProductID,
                Name = p.ProductName,
                UnitsInStock = p.UnitsInStock,
                UnitPrice = p.UnitPrice,
                Discontinued = p.Discontinued,
                Supplier = new Models.Supplier
                {
                    Id = p.Supplier.SupplierID,
                    Name = p.Supplier.CompanyName
                },
                Category = new Models.Category
                {
                    Id = p.Category.CategoryID,
                    Name = p.Category.CategoryName
                }
            });

            // convert to a DataSourceResponse and send back as JSON
            //return this.Json(products.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            return this.Json(products.ToDataSourceResult(request));

        }


        // parse the incoming request from Kendo UI into a DataSourceRequest
        public JsonResult GetRejectedProducts([DataSourceRequest]DataSourceRequest request)
        {

            // LINQ query to select products and map to model objects
            var products = _context.Products.Select(p => new Models.Product
            {
                Id = p.ProductID,
                Name = p.ProductName,
                UnitsInStock = p.UnitsInStock,
                UnitPrice = p.UnitPrice,
                Discontinued = p.Discontinued,
                Supplier = new Models.Supplier
                {
                    Id = p.Supplier.SupplierID,
                    Name = p.Supplier.CompanyName
                },
                Category = new Models.Category
                {
                    Id = p.Category.CategoryID,
                    Name = p.Category.CategoryName
                }
            });

            // convert to a DataSourceResponse and send back as JSON
            //return this.Json(products.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            return this.Json(products.ToDataSourceResult(request));

        }


        // parse the incoming request from Kendo UI into a DataSourceRequest
        public JsonResult GetPendingProducts([DataSourceRequest]DataSourceRequest request)
        {

            // LINQ query to select products and map to model objects
            var products = _context.Products.Select(p => new Models.Product
            {
                Id = p.ProductID,
                Name = p.ProductName,
                UnitsInStock = p.UnitsInStock,
                UnitPrice = p.UnitPrice,
                Discontinued = p.Discontinued,
                Supplier = new Models.Supplier
                {
                    Id = p.Supplier.SupplierID,
                    Name = p.Supplier.CompanyName
                },
                Category = new Models.Category
                {
                    Id = p.Category.CategoryID,
                    Name = p.Category.CategoryName
                }
            });

            // convert to a DataSourceResponse and send back as JSON
            //return this.Json(products.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            return this.Json(products.ToDataSourceResult(request));

        }

        // parse the incoming request from Kendo UI into a DataSourceRequest
        public JsonResult GetAllOrders([DataSourceRequest]DataSourceRequest request)
        {

            var orders = _context.Orders.Select(o => new Models.OrderViewModel
            {
                Id=o.OrderID,
                CustomerId=o.Customer.CustomerID,
                CustomerName=o.Customer.CompanyName,
                OrderDate=(DateTime)o.OrderDate,
                RequiredDate = (DateTime)o.RequiredDate,
                Status = 1
            });

            return this.Json(orders.ToDataSourceResult(request));

        }

        public ActionResult GetActivePendingOrders()
        {
            IList<Models.OrderList> orderList = new List<Models.OrderList>();
            Models.OrderList newOrderList;

            using (IDbConnection oaConnection = dbContext.Connection)
            {
                string SqlQueryString = "SELECT [Order].ID, [Order].OrderDate, [Order].DueDate, Customer.Name, Customer.AccountReference, Customer.UID,  ";
                SqlQueryString = SqlQueryString + " SalesRepresentative.Name AS SaleRep, OrderStatusCode.Title FROM [Order] INNER JOIN ";
                SqlQueryString = SqlQueryString + " Customer ON [Order].CustomerID = Customer.ID INNER JOIN SalesRepresentative ON [Order].SalesPersonID=SalesRepresentative.ID ";
                SqlQueryString = SqlQueryString + " INNER JOIN OrderStatusCode ON [Order].Status = OrderStatusCode.ID WHERE ([Order].Status = 1) ";

                using (IDbCommand oaCommand = oaConnection.CreateCommand())
                {
                    oaCommand.CommandText = SqlQueryString;
                    using (IDataReader reader = oaCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            newOrderList = new Models.OrderList();

                            newOrderList.OrderID = reader.GetInt64(0);
                            newOrderList.OrderTitle = string.Format("OrderID={0}, Customer={1}", reader.GetInt64(0), reader.GetString(3));
                            newOrderList.OrderDate = reader.GetDateTime(1);
                            newOrderList.DueDate = reader.GetDateTime(2);
                            newOrderList.Customer = reader.GetString(3);
                            newOrderList.SalesRep = reader.GetString(6);
                            newOrderList.Status = reader.GetString(7);

                            orderList.Add(newOrderList);
                        }


                    }
                }
            }

            var orders = orderList.AsQueryable();


            return Json(orders, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetOrderDetail([DataSourceRequest]DataSourceRequest request)
        {
            IList<Models.OrderDetailList> orderDetailList = new List<Models.OrderDetailList>();
            Models.OrderDetailList newOrderDetailList;

            using (IDbConnection oaConnection = dbContext.Connection)
            {
                string SqlQueryString = "SELECT OrderDetail.SalesOrderDetailID, OrderDetail.SalesOrderID, OrderDetail.ProductID, Product.Name,  ";
                SqlQueryString = SqlQueryString + " OrderDetail.UnitPrice, OrderDetail.OrderQuantity, OrderDetail.LineTotal, OrderDetail.CustomerID,  ";
                SqlQueryString = SqlQueryString + " OrderDetail.PartnerID FROM OrderDetail INNER JOIN ";
                SqlQueryString = SqlQueryString + " Product ON OrderDetail.ProductID = Product.ID WHERE OrderDetail.SalesOrderID <0";

                using (IDbCommand oaCommand = oaConnection.CreateCommand())
                {
                    oaCommand.CommandText = SqlQueryString;
                    using (IDataReader reader = oaCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            newOrderDetailList = new Models.OrderDetailList();

                            newOrderDetailList.OrderDetailID = reader.GetInt64(0);
                            //newOrderDetailList.OrderID = reader.GetInt64(1);
                            //newOrderDetailList.OrderTitle = string.Format("OrderID={0}, Customer={1}", reader.GetInt64(0), reader.GetString(3));
                            newOrderDetailList.ProductID = reader.GetInt64(2);
                            newOrderDetailList.ProductName = reader.GetString(3);

                            newOrderDetailList.UnitPrice = reader.IsDBNull(4) ? 0 : reader.GetDecimal(4);
                            newOrderDetailList.OrderQuantity = reader.IsDBNull(5) ? 0 : reader.GetInt32(5);
                            newOrderDetailList.LineTotal = reader.IsDBNull(6) ? 0 : reader.GetDecimal(6);

      
                            orderDetailList.Add(newOrderDetailList);
                        }


                    }
                }
            }

            var orderDetail = orderDetailList.AsQueryable();


            //return Json(orderDetail, JsonRequestBehavior.AllowGet);

            return this.Json(orderDetail.ToDataSourceResult(request));
        }
    }
}
