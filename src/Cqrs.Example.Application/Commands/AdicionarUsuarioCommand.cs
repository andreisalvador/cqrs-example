using Cqrs.Example.Application.Commands.Validations;
using Cqrs.Example.Core.Enums;
using Cqrs.Example.Core.Messaging;

namespace Cqrs.Example.Application.Commands
{
    public class AdicionarUsuarioCommand : Command<AdicionarUsuarioCommand>
    {
        public string Nome { get; private set; }
        public byte Idade { get; private set; }
        public Sexo Sexo { get; private set; }

        public AdicionarUsuarioCommand(string nome, byte idade, Sexo sexo) : base(new AdicionarUsuarioCommandValidation())
        {
            Nome = nome;
            Idade = idade;
            Sexo = sexo;
        }

        public override bool IsValid()
            => IsValid(this);
    }
}
