using Cqrs.Example.Application.Commands;
using Cqrs.Example.Application.Handlers;
using Cqrs.Example.Application.Queries;
using Cqrs.Example.Application.Queries.DTOs;
using Cqrs.Example.Core.Data;
using Cqrs.Example.Core.Messaging;
using Cqrs.Example.Core.Messaging.Interfaces;
using Cqrs.Example.Domain;
using Cqrs.Example.Infrastructure.Data;
using Cqrs.Example.Infrastructure.Data.Repositories;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Reflection;

namespace Cqrs.Example.Infrastructure.Ioc
{
    public static class DependencyInjection
    {
        public static void ResolveDependencies(this IServiceCollection services, Assembly applicationAssembly)
        {
            services.AddLogging(x => x.AddConsole());
            AddDbContext(services);
            AddRepositories(services);
            AddMessaging(services, applicationAssembly);
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IRepository<Usuario>, UsuarioRepository>();
        }

        private static void AddMessaging(IServiceCollection services, Assembly applicationAssembly)
        {
            services.AddMediatR(applicationAssembly);
            services.AddScoped<IBus, Bus>();
            services.AddScoped<IRequestHandler<AdicionarUsuarioCommand, ValidationResult>, UsuarioCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverUsuarioCommand, ValidationResult>, UsuarioCommandHandler>();
            services.AddScoped<IRequestHandler<ObterUsuariosAtivosPorNomeIdadeQuery, IEnumerable<UsuarioDto>>, UsuarioQueryHandler>();
        }

        private static void AddDbContext(IServiceCollection services)
        {            
            services.AddDbContext<CqrsExampleContext>(options => options.UseNpgsql("User ID = andrei.salvador;Password=pgpass;Server=localhost;Port=5433;Database=CQRS_DB;Integrated Security=true;Pooling=true"));
        }
    }
}
