using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Context.Contract.CQRS
{
    public abstract class CommandBase : IApplicationCommand
    {
        public string Id { get; set; }

        protected CommandBase()
        {
            Id = Guid.NewGuid().ToString();
        }

        protected CommandBase(string id)
        {
            Id = id;
        }

        public override bool Equals(object obj)
        {
            bool result = false;
            var command = obj as CommandBase;
            if (obj != null && this.Id == command.Id)
            {
                result = true;
            }
            return result;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
