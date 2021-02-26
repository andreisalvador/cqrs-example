using System.Threading;
using System.Threading.Tasks;
using Cqrs.Example.Application.Commands;
using Cqrs.Example.Application.Events;
using Cqrs.Example.Core.Data;
using Cqrs.Example.Core.Messaging.Interfaces;
using Cqrs.Example.Domain;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cqrs.Example.Application.Handlers
{
    public class UsuarioCommandHandler :
        IRequestHandler<AdicionarUsuarioCommand, ValidationResult>,
        IRequestHandler<RemoverUsuarioCommand, ValidationResult>
    {
        private readonly ILogger<UsuarioCommandHandler> _logger;
        private readonly IRepository<Usuario> _usuarioRepository;
        private readonly IBus _bus;
        public UsuarioCommandHandler(ILogger<UsuarioCommandHandler> logger, IRepository<Usuario> usuarioRepository, IBus bus)
        {
            _logger = logger;
            _usuarioRepository = usuarioRepository;
            _bus = bus;
        }
        public async Task<ValidationResult> Handle(AdicionarUsuarioCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                _logger.LogError($"{nameof(AdicionarUsuarioCommand)} inválido.");
                return request.ValidationResult;
            }

            Usuario novoUsuario = new Usuario(request.Nome, request.Idade, request.Sexo);

            _usuarioRepository.Add(novoUsuario);

            if (await _usuarioRepository.Commit())
            {
                _logger.LogInformation($"Id do usuário criado {novoUsuario.Id}");
                await _bus.EnviarEvento(new UsuarioAdicionadoEvent(novoUsuario.Id, novoUsuario.Nome, novoUsuario.Idade, (byte)novoUsuario.Sexo));
            }
            else
                _logger.LogError($"Usuario não pode ser inserido no banco.");

            return request.ValidationResult;
        }

        public async Task<ValidationResult> Handle(RemoverUsuarioCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                _logger.LogError($"{nameof(RemoverUsuarioCommand)} inválido.");
                return request.ValidationResult;
            }

            Usuario usuario = await _usuarioRepository.GetById(request.UsuarioId);
            _usuarioRepository.Remove(usuario);

            if (await _usuarioRepository.Commit())
            {
                _logger.LogInformation($"Id do usuário removido {usuario.Id} com sucesso.");
                await _bus.EnviarEvento(new UsuarioRemovidoEvent(usuario.Id));
            }
            else
                _logger.LogError($"Usuario não pode ser removido no banco.");

            return request.ValidationResult;
        }
    }
}
