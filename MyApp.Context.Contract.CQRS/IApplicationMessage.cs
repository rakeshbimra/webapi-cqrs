using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Context.Contract.CQRS
{
    /// <summary>
    /// Base for commands 
    /// </summary>
    public interface IApplicationMessage
    {
        string Id { get; }
    }
}
