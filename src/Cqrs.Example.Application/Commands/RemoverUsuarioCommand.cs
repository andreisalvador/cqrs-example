using NetDevPack.Messaging;
using System;

namespace Cqrs.Example.Application.Commands
{
    public class RemoverUsuarioCommand : Command
    {
        public Guid UsuarioId { get; private set; }

        public RemoverUsuarioCommand(Guid usuarioId)
        {
            UsuarioId = usuarioId;
        }
    }
}
