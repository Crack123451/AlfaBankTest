using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlfaBankTest.Service.Models
{
    public class Shop
    {
        [JsonProperty("count")]
        public int Count { get; set; }
        
        [JsonProperty("products")]
        public ShopItem[] Products { get; set; }
    }

    public class ShopItem
    {
        [JsonProperty("part_number")]
        public int PartNumber { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("supplier")]
        public string Supplier { get; set; }

        [JsonProperty("vendor")]
        public string Vendor { get; set; }

        [JsonProperty("vendor_part_number")]
        public int VendorPartNumber { get; set; }

        [JsonProperty("vendor_description")]
        public string VendorDesciption { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }
    }
}