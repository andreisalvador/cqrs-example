using Cqrs.Example.Application.Queries.DTOs;
using Cqrs.Example.Core.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cqrs.Example.Application.Queries
{
    public class ObterUsuarioPorId : Query<UsuarioDto>
    {
        public Guid UsuarioId { get; private set; }
        public ObterUsuarioPorId(Guid usuarioId)
        {
            UsuarioId = usuarioId;
        }
    }
}
