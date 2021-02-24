using Cqrs.Example.Application.Queries.DTOs;
using Cqrs.Example.Core.Messaging;
using System.Collections.Generic;

namespace Cqrs.Example.Application.Queries
{
    public class ObterUsuariosAtivoPorNomeIdade : Query<IEnumerable<UsuarioDto>>
    {
        public string Nome { get; private set; }
        public byte Idade { get; private set; }
        public ObterUsuariosAtivoPorNomeIdade(string nome, byte idade)
        {
            Nome = nome;
            Idade = idade;
        }
    }
}
