using Cqrs.Example.Core;
using Cqrs.Example.Core.Enums;

namespace Cqrs.Example.Domain
{
    public class Usuario : Entity
    {
        public string Nome { get; private set; }
        public byte Idade { get; private set; }
        public Sexo Sexo { get; private set; }
        public bool Ativo { get; private set; }
        public Usuario(string nome, byte idade, Sexo sexo, bool ativo = true)
        {
            Nome = nome;
            Idade = idade;
            Sexo = sexo;
            Ativo = ativo;
        }

        public void DesativarUsuario()
            => Ativo = false;
    }
}
