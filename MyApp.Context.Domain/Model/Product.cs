using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Context.Domain.Model
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
