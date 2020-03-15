using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Context.Contract.CQRS.Exceptions
{
    /// <summary>
    /// Exception to throw when query or command has timeouted
    /// </summary>
    [Serializable]
    public class QueryTimeoutException : Exception
    {
        #region Ctors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="message">Message</param>
        public QueryTimeoutException(string message) : base(message)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="exeption">Inner Exception</param>
        public QueryTimeoutException(string message, Exception exeption) : base(message, exeption)
        {
        }

        #endregion
    }
}
