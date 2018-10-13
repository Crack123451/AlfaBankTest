using AlfaBankTest.Service.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace AlfaBankTest.Service.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values/5
        public IEnumerable<string> Get(int id)
        {
            if (HomeController.dataShop != null && id >= 0 && HomeController.dataShop.Count > id)
                return new string[] {
                    HomeController.dataShop.Products[id].PartNumber.ToString(),
                    HomeController.dataShop.Products[id].Name,
                    HomeController.dataShop.Products[id].Description,
                    HomeController.dataShop.Products[id].Supplier,
                    HomeController.dataShop.Products[id].Vendor,
                    HomeController.dataShop.Products[id].VendorPartNumber.ToString(),
                    HomeController.dataShop.Products[id].VendorDesciption,
                    HomeController.dataShop.Products[id].Price.ToString(),
                    HomeController.dataShop.Products[id].Image
                };
            return null;
        }

        // GET api/values/?request=count
        public string Get(string request)
        {
            if (HomeController.dataShop==null)
                return null;
            switch(request)
            {
                case "count":
                    return HomeController.dataShop.Count.ToString();
                case "maxPrice":
                    return HomeController.dataShop.Products.Select(p => double.Parse(p.Price, CultureInfo.InvariantCulture)).Max().ToString();
                case "minPrice":
                    return HomeController.dataShop.Products.Select(p => double.Parse(p.Price, CultureInfo.InvariantCulture)).Min().ToString();
                case "averagePrice":
                    return HomeController.dataShop.Products.Select(p => double.Parse(p.Price, CultureInfo.InvariantCulture)).Average().ToString();
                default:
                    return null;
            }            
        }
    }
}
