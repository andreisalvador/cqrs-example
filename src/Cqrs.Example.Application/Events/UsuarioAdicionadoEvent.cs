using Cqrs.Example.Core.Messaging;
using System;

namespace Cqrs.Example.Application.Events
{
    public class UsuarioAdicionadoEvent : Event
    {
        public Guid UsuarioIdAdicionadoOutroSistemaOuModulo { get; private set; }
        public string Nome { get; private set; }
        public byte Idade { get; private set; }
        public byte Sexo { get; private set; }

        public UsuarioAdicionadoEvent(Guid usuarioIdAdicionadoOutroSistemaOuModulo, string nome, byte idade, byte sexo)
        {
            UsuarioIdAdicionadoOutroSistemaOuModulo = usuarioIdAdicionadoOutroSistemaOuModulo;
            Nome = nome;
            Idade = idade;
            Sexo = sexo;
        }
    }
}
