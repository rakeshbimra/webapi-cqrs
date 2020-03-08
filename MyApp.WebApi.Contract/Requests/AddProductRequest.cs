using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.WebApi.Contract.Requests
{
    public class AddProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
