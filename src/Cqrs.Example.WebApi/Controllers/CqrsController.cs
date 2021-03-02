using Cqrs.Example.Application.Commands;
using Cqrs.Example.Application.Queries;
using Cqrs.Example.Application.Queries.DTOs;
using Cqrs.Example.Core.Enums;
using Cqrs.Example.Core.Messaging.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cqrs.Example.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CqrsController : ControllerBase
    {
        private readonly IBus _bus;

        public CqrsController(IBus bus)
        {
            _bus = bus;
        }

        [HttpPost("adicionar-usuario")]
        public async Task<bool> AdicionarUsuario(string nome, byte idade, Sexo sexo)
        {
            await _bus.EnviarComando(new AdicionarUsuarioCommand(nome, idade, sexo));
            return true;
        }

        [HttpDelete("remover-usuario")]
        public async Task<bool> RemoverUsuario(Guid usuarioId)
        {
            await _bus.EnviarComando(new RemoverUsuarioCommand(usuarioId));
            return true;
        }

        [HttpGet("obter-usuarios-ativos")]
        public async Task<IEnumerable<UsuarioDto>> ObterUsuariosAtivosPorNomeIdade(string nome, byte idade)
        {
            IEnumerable<UsuarioDto> usuariosEncontrado = await _bus.ExecutarQuery<ObterUsuariosAtivosPorNomeIdadeQuery, IEnumerable<UsuarioDto>>(new ObterUsuariosAtivosPorNomeIdadeQuery(nome, idade));
            return usuariosEncontrado;
        }
    }
}
