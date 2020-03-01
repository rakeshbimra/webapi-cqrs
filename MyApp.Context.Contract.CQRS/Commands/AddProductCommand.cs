using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Context.Contract.CQRS.Commands
{
    public class AddProductCommand : CommandBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
