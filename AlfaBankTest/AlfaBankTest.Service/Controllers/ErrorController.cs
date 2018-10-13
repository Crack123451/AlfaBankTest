using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AlfaBankTest.Service.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult ApiUnavailable()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://alfa-test-api.dev.kroniak.net/api/v1/products/");
            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException)
            {
                return View();
            }
            return Redirect("~/Home/Index");
        }
    }
}