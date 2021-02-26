using Cqrs.Example.Core.Enums;
using System;

namespace Cqrs.Example.Application.Queries.DTOs
{
    public class UsuarioDto
    {
        public string Nome { get; private set; }
        public byte Idade { get; private set; }
        public string Sexo { get; private set; }
        public bool Ativo { get; private set; }

        public UsuarioDto(string nome, byte idade, Sexo sexo, bool ativo)
        {
            Nome = nome;
            Idade = idade;
            Sexo = Enum.GetName(typeof(Sexo), sexo);
            Ativo = ativo;
        }
    }
}
