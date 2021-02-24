using FluentValidation.Results;
using NetDevPack.Messaging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cqrs.Example.Core.Messaging.Interfaces
{
    public interface IBus
    {
        Task<ValidationResult> EnviarComando<TCommand>(TCommand command) where TCommand : Command;
        Task<TQueryResult> ExecutarQuery<TQuery, TQueryResult>(TQuery query) where TQuery : Query<TQueryResult>;
    }
}
