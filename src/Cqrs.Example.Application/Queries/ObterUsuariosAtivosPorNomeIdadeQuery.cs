using Cqrs.Example.Application.Queries.DTOs;
using Cqrs.Example.Application.Queries.Validations;
using Cqrs.Example.Core.Messaging;
using System.Collections.Generic;

namespace Cqrs.Example.Application.Queries
{
    public class ObterUsuariosAtivosPorNomeIdadeQuery : Query<ObterUsuariosAtivosPorNomeIdadeQuery, IEnumerable<UsuarioDto>>
    {
        public string Nome { get; private set; }
        public byte Idade { get; private set; }
        public ObterUsuariosAtivosPorNomeIdadeQuery(string nome, byte idade) : base(new ObterUsuariosAtivosPorNomeIdadeQueryValidation())
        {
            Nome = nome;
            Idade = idade;
        }

        public override bool IsValid()
            => IsValid(this);
    }
}
