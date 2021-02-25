using Cqrs.Example.Application.Commands;
using Cqrs.Example.Application.Queries;
using Cqrs.Example.Application.Queries.DTOs;
using Cqrs.Example.ConsoleApp.Enums;
using Cqrs.Example.Core.Messaging.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cqrs.Example.ConsoleApp
{
    public class Exemplo
    {
        private readonly IBus _bus;
        public Exemplo(IBus bus)
        {
            _bus = bus;
        }

        public void ExibirMenu()
        {
            Console.WriteLine("1 - Adicionar Usuario");
            Console.WriteLine("2 - Buscar usuário por nome e idade");
            Console.WriteLine("3 - Remover usuário");
            Console.WriteLine("0 - Sair");
            Console.Write(Environment.NewLine);

            Console.Write("Informe a opção escolhida: ");
            byte exemploEscolhido = byte.Parse(Console.ReadLine());

            if (exemploEscolhido == 0)
                return;

            Console.Clear();
            ExecutarExemplo((Exemplos)exemploEscolhido);
        }

        public void ExecutarExemplo(Exemplos example)
        {

            switch (example)
            {
                case Exemplos.AdicionarUsuario:
                    AdicionarUsuarioExemplo();
                    ExibirMenu();
                    break;
                case Exemplos.BuscarUsuario:
                    BuscarUsuarioExemplo();
                    ExibirMenu();
                    break;
                case Exemplos.RemoverUsuario:
                    RemoverUsuarioExemplo();
                    ExibirMenu();
                    break;
            }
        }

        private void BuscarUsuarioExemplo()
        {
            Console.WriteLine("Informe o nome do usuário: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Informe a idade do usuário: ");
            byte idade = byte.Parse(Console.ReadLine());

            ObterUsuariosAtivosPorNomeIdadeQuery query = new ObterUsuariosAtivosPorNomeIdadeQuery(nome, idade);

            if (!query.IsValid())
            {
                foreach (var item in query.ValidationResult.Errors)
                    Console.WriteLine(item.ErrorMessage);
            }
            else
            {
                Task.Run(() =>
                {
                    var usuarios = _bus.ExecutarQuery<ObterUsuariosAtivosPorNomeIdadeQuery, IEnumerable<UsuarioDto>>(query).Result;

                    foreach (UsuarioDto usuario in usuarios)
                        Console.WriteLine($"Usuario de nome {usuario.Nome} e de idadte {usuario.Idade} encontrado com estado de ativo = {usuario.Ativo}");

                }).Wait();
            }

        }

        private void RemoverUsuarioExemplo()
        {
            Console.WriteLine("Qual o ID do usuário a ser deletado?");
            Guid usuarioId = Guid.Parse(Console.ReadLine());

            Task.Run(() => _bus.EnviarComando(new RemoverUsuarioCommand(usuarioId))).Wait();
        }

        private void AdicionarUsuarioExemplo()
        {
            Task.Run(() => _bus.EnviarComando(new AdicionarUsuarioCommand("Andrei", 25, Core.Enums.Sexo.Masculino)));
        }
    }
}
