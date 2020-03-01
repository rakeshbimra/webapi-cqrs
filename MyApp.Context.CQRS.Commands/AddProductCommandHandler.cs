using MyApp.Context.Contract.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Context.CQRS.Commands
{
    public class AddProductCommandHandler : ICommandHandler<AddProductCommand>
    {

        public void Handle(AddProductCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
