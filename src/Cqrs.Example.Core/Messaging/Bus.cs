using Cqrs.Example.Core.Messaging.Interfaces;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;
using System;
using System.Collections.Generic;
using System.Text;
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
        public async Task<ValidationResult> EnviarComando<TCommand>(TCommand command) where TCommand : Command
            => await _mediator.Send(command);

        public async Task<TQueryResult> ExecutarQuery<TQuery, TQueryResult>(TQuery query) where TQuery : Query<TQueryResult>
            => await _mediator.Send(query);
    }
}
