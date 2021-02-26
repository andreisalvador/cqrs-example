using Cqrs.Example.Application.Commands;
using Cqrs.Example.Application.Events;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cqrs.Example.ExternalSystem
{
    public class UsuarioEventHandler :
        INotificationHandler<UsuarioAdicionadoEvent>,
        INotificationHandler<UsuarioRemovidoEvent>
    {
        private readonly ILogger<UsuarioEventHandler> _logger;

        public UsuarioEventHandler(ILogger<UsuarioEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(UsuarioAdicionadoEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Fazendo qualquer coisa com o usuario '{notification.Nome}' de idade '{notification.Idade}' no outro modulo/sistema.");
            return Task.CompletedTask;
        }

        public Task Handle(UsuarioRemovidoEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Fazendo qualquer coisa com o usuario de ID '{notification.UsuarioIdRemovidoOutroSistemaOuModulo}' após" +
                $" ele ser removido no outro modulo/sistema.");
            return Task.CompletedTask;
        }
    }
}
