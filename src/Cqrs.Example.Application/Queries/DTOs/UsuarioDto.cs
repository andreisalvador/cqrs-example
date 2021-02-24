using Cqrs.Example.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cqrs.Example.Application.Queries.DTOs
{
    public class UsuarioDto
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public byte Idade { get; private set; }
        public Sexo Sexo { get; private set; }
        public bool Ativo { get; private set; }
    }
}
