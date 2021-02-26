using Cqrs.Example.Core.Messaging.Interfaces;
using FluentValidation.Results;
using MediatR;
using System.Threading.Tasks;

namespace Cqrs.Example.Core.Messaging
{
    public class Bus : IBus
    {
        private readonly IMediator _mediator;

        public Bus(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<ValidationResult> EnviarComando<TCommand>(TCommand command) where TCommand : Command<TCommand>
            => await _mediator.Send(command);

        public async Task EnviarEvento<TEvent>(TEvent @event) where TEvent : Event
            => await _mediator.Publish(@event);

        public async Task<TQueryResult> ExecutarQuery<TQuery, TQueryResult>(TQuery query) where TQuery : Query<TQuery, TQueryResult>
            => await _mediator.Send(query);
    }
}
