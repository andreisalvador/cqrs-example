using Cqrs.Example.Core.Enums;

namespace Cqrs.Example.Application.Queries.DTOs
{
    public class UsuarioDto
    {
        public string Nome { get; private set; }
        public byte Idade { get; private set; }
        public Sexo Sexo { get; private set; }
        public bool Ativo { get; private set; }

        public UsuarioDto(string nome, byte idade, Sexo sexo, bool ativo)
        {
            Nome = nome;
            Idade = idade;
            Sexo = sexo;
            Ativo = ativo;
        }
    }
}
