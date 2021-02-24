using Cqrs.Example.Core.Data;
using Cqrs.Example.Domain;
using Cqrs.Example.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using MediatR;
using System.Reflection;

namespace Cqrs.Example.Infrastructure.Ioc
{
    public static class DependencyInjection
    {
        public static void ResolveDependencies(this IServiceCollection services, Assembly applicationAssembly)
        {
            AddDbContext(services);
            AddRepositories(services);
            AddMessaging(services, applicationAssembly);
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddTransient<IRepository<Usuario>, UsuarioRepository>();
        }

        private static void AddMessaging(IServiceCollection services, Assembly applicationAssembly)
        {
            services.AddMediatR(applicationAssembly);
            services.AddSingleton<IMediator, Mediator>();
        }

        private static void AddDbContext(IServiceCollection services)
        {
            throw new NotImplementedException();
        }
    }
}
