using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Context.Contract.CQRS.Exceptions
{
    /// <summary>
    /// Command timeout exception
    /// </summary>
    public class CommandTimeoutException:Exception
    {
        #region Ctors

        public CommandTimeoutException(string message) : base(message)
        {
        }

        public CommandTimeoutException(string message, Exception exception) : base(message, exception)
        { }

        #endregion
    }
}
