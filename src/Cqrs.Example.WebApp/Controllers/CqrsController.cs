using Cqrs.Example.Application.Commands;
using Cqrs.Example.Application.Queries;
using Cqrs.Example.Application.Queries.DTOs;
using Cqrs.Example.Core.Messaging.Interfaces;
using Cqrs.Example.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Cqrs.Example.WebApp.Controllers
{
    public class CqrsController : Controller
    {
        private readonly ILogger<CqrsController> _logger;
        private readonly IBus _bus;

        public CqrsController(ILogger<CqrsController> logger, IBus bus)
        {
            _logger = logger;
            _bus = bus;
        }

        public async Task<IActionResult> AdicionarUsuario()
        {
            await _bus.EnviarComando(new AdicionarUsuarioCommand("Andrei", 12, Core.Enums.Sexo.Feminino));
            return View();
        }

        [HttpGet("{usuarioId:guid}")]
        public async Task<IActionResult> RemoverUsuario(Guid usuarioId)
        {
            await _bus.EnviarComando(new RemoverUsuarioCommand(usuarioId));
            return View();
        }

        public async Task<IActionResult> ObterUsuarioAtivoPorNomeIdade(string nome, byte idade)
        {
            IEnumerable<UsuarioDto> usuariosEncontrado = await _bus.ExecutarQuery<ObterUsuariosAtivosPorNomeIdadeQuery, IEnumerable<UsuarioDto>>(new ObterUsuariosAtivosPorNomeIdadeQuery(nome, idade));
            return View(usuariosEncontrado);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
