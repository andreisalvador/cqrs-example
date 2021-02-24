using Cqrs.Example.Application.Commands;
using Cqrs.Example.Core.Messaging.Interfaces;
using Cqrs.Example.Infrastructure.Ioc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Cqrs.Example.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            DependencyInjection.ResolveDependencies(serviceCollection, typeof(Program).GetTypeInfo().Assembly);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            IBus bus = serviceProvider.GetRequiredService<IBus>();

            Task.WaitAll(bus.EnviarComando(new AdicionarUsuarioCommand("Andrei", 25, Core.Enums.Sexo.Masculino)));


            Console.WriteLine("Hello World!");
        }
    }
}
