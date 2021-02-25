using Cqrs.Example.Application.Queries;
using Cqrs.Example.Application.Queries.DTOs;
using Cqrs.Example.Core.Messaging.Interfaces;
using Cqrs.Example.Infrastructure.Ioc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace Cqrs.Example.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<Exemplo>();
            DependencyInjection.ResolveDependencies(serviceCollection, typeof(Program).GetTypeInfo().Assembly);
            Exemplo exemplo = serviceCollection.BuildServiceProvider().GetService<Exemplo>();

            exemplo.ExibirMenu();
        }
    }
}
