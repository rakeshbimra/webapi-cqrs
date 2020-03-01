using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Context.CQRS.Commands
{
    /// <summary>
    /// Handles application commands
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    public interface ICommandHandler<TCommand>
    {
        /// <summary>
        /// Execute command
        /// </summary>
        /// <param name="command"></param>
        void Handle(TCommand command);
    }

    /// <summary>
    /// Handles application commands and return result
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public interface ICommandHandler<TCommand, TResult>
    {
        TResult Handle(TCommand command);
    }
}
