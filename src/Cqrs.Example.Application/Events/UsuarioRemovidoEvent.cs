using Cqrs.Example.Core.Messaging;
using System;

namespace Cqrs.Example.Application.Events
{
    public class UsuarioRemovidoEvent : Event
    {
        public Guid UsuarioIdRemovidoOutroSistemaOuModulo { get; private set; }

        public UsuarioRemovidoEvent(Guid usuarioIdRemovidoOutroSistemaOuModulo)
        {
            UsuarioIdRemovidoOutroSistemaOuModulo = usuarioIdRemovidoOutroSistemaOuModulo;
        }
    }
}
