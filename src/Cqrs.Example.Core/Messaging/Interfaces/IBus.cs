using FluentValidation.Results;
using System.Threading.Tasks;

namespace Cqrs.Example.Core.Messaging.Interfaces
{
    public interface IBus
    {
        Task<ValidationResult> EnviarComando<TCommand>(TCommand command) where TCommand : Command<TCommand>;
        Task<TQueryResult> ExecutarQuery<TQuery, TQueryResult>(TQuery query) where TQuery : Query<TQuery, TQueryResult>;
    }
}
