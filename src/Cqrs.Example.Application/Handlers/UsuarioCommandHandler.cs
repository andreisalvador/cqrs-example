using System.Threading;
using System.Threading.Tasks;
using Cqrs.Example.Application.Commands;
using Cqrs.Example.Domain;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cqrs.Example.Application.Handlers
{
    public class UsuarioCommandHandler : IRequestHandler<AdicionarUsuarioCommand, ValidationResult>
    {
        private readonly ILogger _logger;
        public UsuarioCommandHandler(ILogger logger)
        {
            _logger = logger;
        }
        public async Task<ValidationResult> Handle(AdicionarUsuarioCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                _logger.LogError($"{nameof(AdicionarUsuarioCommand)} inválido.");
                return request.ValidationResult;
            }

            //
            Usuario novoUsuario = new Usuario(request.Nome, request.Idade, request.Sexo);

            //salvar no banco
            _logger.LogInformation($"Id do usuário criado {novoUsuario.Id}");
            
            return request.ValidationResult;
        }
    }
}
