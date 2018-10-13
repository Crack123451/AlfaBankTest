using AlfaBankTest.Service.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace AlfaBankTest.Service.Controllers
{
    public class HomeController : Controller
    {
        public static Shop dataShop;

        [OutputCache(Duration = 180, Location = OutputCacheLocation.ServerAndClient)]
        public ActionResult Index()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://alfa-test-api.dev.kroniak.net/api/v1/products/");
            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException)
            {
                return Redirect("Error/ApiUnavailable");    
            }
            dataShop = GetDataBaseShop(response);
            return View();
        }

        public Shop GetDataBaseShop(HttpWebResponse response)
        {
            string data = "";
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;
                if (response.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                }
                data = readStream.ReadToEnd();
                response.Close();
                readStream.Close();
                dataShop = HtmlToJson(data);
            }
            return dataShop;
        }

        public Shop HtmlToJson(string html)
        {
            var obj = JsonConvert.DeserializeObject<Shop>(html);
            return obj;
        }
    }
}
