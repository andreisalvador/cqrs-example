using Cqrs.Example.Core.Enums;
using NetDevPack.Messaging;

namespace Cqrs.Example.Application.Commands
{
    public class AdicionarUsuarioCommand : Command
    {
        public string Nome { get; private set; }
        public byte Idade { get; private set; }
        public Sexo Sexo { get; private set; }

        public AdicionarUsuarioCommand(string nome, byte idade, Sexo sexo)
        {
            Nome = nome;
            Idade = idade;
            Sexo = sexo;
        }
    }
}
