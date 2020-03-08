using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.WebApi.Contract.Response
{
    public class ProductResponse
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "price")]
        public string Price { get; set; }
    }
}
