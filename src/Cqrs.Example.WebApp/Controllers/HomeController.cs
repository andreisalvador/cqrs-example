using Cqrs.Example.Application.Commands;
using Cqrs.Example.Core.Messaging.Interfaces;
using Cqrs.Example.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Cqrs.Example.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBus _bus;

        public HomeController(ILogger<HomeController> logger, IBus bus)
        {
            _logger = logger;
            _bus = bus;
        }

        public async Task<IActionResult> Index()
        {
            await _bus.EnviarComando(new AdicionarUsuarioCommand("Andrei", 12, Core.Enums.Sexo.Feminino));
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
