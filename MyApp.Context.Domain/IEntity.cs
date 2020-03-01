using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Context.Domain
{
    public class IEntity<TId> where TId : struct
    {
        TId Id { get; set; }
    }
}
