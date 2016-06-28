using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace rEX.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        [Route("orders/{orderId}/show")]
        public ActionResult GetOrderById(int orderId)
        {
            return View();
        }
    }
}