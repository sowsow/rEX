using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace rEX.Controllers
{
    public class RDController : Controller
    {
        // GET: RD
        // Implicit action name: Index
        public ActionResult Index()
        {
            // ViewData Dictionary 
            //-- Packed into [view context]
            //-- APS.NET MVC infrastructure moves data from the controller level to view level
            //-- [view] objects (ViewPage for ASPX && WebViewPage for Razor) expose ViewData to View Template
            ViewData["PageTitle"] = "R&D of ASP.NET MVC"; // Not Recommended, hard to maintain when Controller & View become large


            // ViewBag Dictionary -- Dynamic
            // -- Available since MVC3 and .NET 4, whereas ViewData is available for all MVC version and .NET 2
            // -- Relies on Dynamic Language Runtime (DLR) to interpret expressions and Run Time/Execution Time
            // -- VS IntelliSense can't indicate anything while JetBrains ReSharper can
            ViewBag.AuthorName = "Rex";


            // Strongly Typed View Models
            // -- Define a view-model class for each view that is added to the application
            /*  e.g.
                // Pack data for the view using a view-specific container object
                var model = new MyViewModel();  // name: [Controller][View]["ViewModel"] --> RDIndexViewModel
                // Populate the model
                ...
                // Trigger the view
                return View(model);
            */

            return View();  // Same as View("index"); // if nothing, view name == action/method name by default
        }


        #region [NonAction] [ActionName("abc")]
        [NonAction]
        public ActionResult About()
        {
            return null;
        }

        [ActionName("About")]
        public ActionResult WhateverActionName()
        {
            return View();
        }
        #endregion [NonAction] [ActionName("abc")]


        // Example - Controller Action
        public ActionResult Echo()
        {
            #region Capture Request Data/Params
            // Capture data in a manual way from Request
            var data1 = Request.Params["today"] ?? string.Empty;
            var data2 = Request["TODAY"] ?? string.Empty;

            // Capture data in a manual way from RouteData
            var data3 = RouteData.Values["data"] ?? string.Empty; // RouteData.Values["DATA"] ?? string.Empty;

            // http://yourserver/echo?today=21/06/2018
            var data4 = RouteData.Values["data"] ??
                        (Request.Params["today"] ?? string.Empty);

            // ValueProvider Dictionary -- Property
            // Sequence: Child Action Values --> Form Data (Rqeust.Form) --> Route Data --> Query String --> Posted Files
            var data5 = ValueProvider.GetValue("data"); // returns ValueProviderResult type && case sensitive && NO access to Cookies or Request Header
            var data6 = data5.AttemptedValue; // string type
            var data7 = data5.RawValue; // Object type
            var data8 = ValueProvider.GetValue("data").AttemptedValue ??
                        (ValueProvider.GetValue("today").AttemptedValue ?? string.Empty);
            #endregion Capture Request Data/Params


            #region Perform Tasks
            #endregion Perform Tasks


            #region Produce Action Results
            // General: string, JSON..       || No Content     || Redirect to another URL
            // ContentResult                 || EmptyResult    || 
            // FileContentResult(byte Array) || FilePathResult || FileStreamResult(Stream Obj) || --> Derived from FileResult Class
            // HttpNotFoundResult(404)       || HttpUnauthorizedResult(401) || --> Derived from HttpStatusCodeResult Class
            // JavaScriptResult    || JSONResult ||
            // RedirectResult(302) || RedirectToRouteResult(302) determined by controller/action pairs or route names ||
            // PartialViewResult   || ViewResult --> Derived from ViewResultBase Class
                          
            return View();  // ViewResult -- object of type ActionResult
            #endregion Produce Action Results
        }


        // Example - Return JavaScript Content
        public JavaScriptResult GetJavaScriptResult()
        {
            var script = "alert('Hello World')";
            return JavaScript(script);
        }


        // Example - Return JSON Content
        public JsonResult GetJSONResult()
        {
            // Grab data from Repository
            //var mockData = _customerRepository.GetAll();
            var mockData = @"{'employees':[
                                { 'firstName':'John', 'lastName':'Doe'},
                                { 'firstName':'Anna', 'lastName':'Smith'},
                                { 'firstName':'Peter', 'lastName':'Jones'}
                             ]}";

            // Serialize to JSON and Return
            return Json(mockData);
        }


        // Example - Async Controller Method ---> async && await
        public async Task<ActionResult> Rss()
        {
            // Run heavy operations
            var client = new HttpClient();
            var rss = await client.GetStringAsync("someRssUrl");

            // Parse RSS and build the View-Model
            /* Create a MockModel and Return it with fulfilled Attributes
            var model = new HomeIndexModel(); 
            model.News = ParseRssInternal(rss);
            return model;
            */

            return null;
        }


        // Example - Attribute Routing 
        [Route("rd/{projectName}/show")]
        public ActionResult GetRDProjectByName(string projectName)
        {
            return View();
        }


    }
}