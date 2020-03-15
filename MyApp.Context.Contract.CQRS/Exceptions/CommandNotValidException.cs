using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Context.Contract.CQRS.Exceptions
{
    /// <summary>
    /// Throw when command validation failed
    /// </summary>
    [Serializable]
    public class CommandNotValidException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        public IList<string> ErrorMessages { get; set; }

        public CommandNotValidException(IList<string> errorMessages)
            : base("The command was invalid. See ErrorMessages property for more information.")
        {
            if (errorMessages == null) { throw new ArgumentNullException("errorMessages", @"Error messages must be set to inform caller of why validation failed."); }
            if (errorMessages.Count < 1) { throw new ArgumentException(@"Error messages must contain information why validation failed to inform caller.", "errorMessages"); }

            ErrorMessages = errorMessages;
        }

    }
}
