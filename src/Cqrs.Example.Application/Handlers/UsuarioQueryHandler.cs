using Cqrs.Example.Application.Queries;
using Cqrs.Example.Application.Queries.DTOs;
using Cqrs.Example.Core.Data;
using Cqrs.Example.Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Cqrs.Example.Application.Handlers
{
    public class UsuarioQueryHandler : IRequestHandler<ObterUsuariosAtivoPorNomeIdade, IEnumerable<UsuarioDto>>
    {
        private readonly IRepository<Usuario> _usuarioRepository;
        private readonly ILogger<UsuarioQueryHandler> _logger;

        public UsuarioQueryHandler(IRepository<Usuario> usuarioRepository, ILogger<UsuarioQueryHandler> logger)
        {
            _usuarioRepository = usuarioRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<UsuarioDto>> Handle(ObterUsuariosAtivoPorNomeIdade request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Consultando usuario com nome '{request.Nome}'.");

            IEnumerable<Usuario> usuarios = await _usuarioRepository.GetWhere(usuario => usuario.Nome.Equals(request.Nome) && usuario.Idade == request.Idade);

            if (!usuarios.Any())
            {
                _logger.LogError($"Usuario de nome '{request.Nome}' não encontrado.");
                return null;
            }

            List<UsuarioDto> usuariosEncontrados = new List<UsuarioDto>();

            foreach (Usuario usuario in usuarios)
                usuariosEncontrados.Add(new UsuarioDto(usuario.Nome, usuario.Idade, usuario.Sexo, usuario.Ativo));

            return usuariosEncontrados;
        }
    }
}
