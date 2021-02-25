using FluentValidation;
using System;

namespace Cqrs.Example.Application.Commands.Validations
{
    public class RemoverUsuarioCommandValidation : AbstractValidator<RemoverUsuarioCommand>
    {
        public RemoverUsuarioCommandValidation()
        {
            RuleFor(c => c.UsuarioId)
                .NotEqual(Guid.Empty)
                .WithMessage("O id do usuário é obrigatório.");
        }
    }
}
