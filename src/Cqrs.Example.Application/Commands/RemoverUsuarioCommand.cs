using Cqrs.Example.Application.Commands.Validations;
using Cqrs.Example.Core.Messaging;
using System;

namespace Cqrs.Example.Application.Commands
{
    public class RemoverUsuarioCommand : Command<RemoverUsuarioCommand>
    {
        public Guid UsuarioId { get; private set; }

        public RemoverUsuarioCommand(Guid usuarioId) : base(new RemoverUsuarioCommandValidation())
        {
            UsuarioId = usuarioId;
        }

        public override bool IsValid()
            => IsValid(this);
    }
}
