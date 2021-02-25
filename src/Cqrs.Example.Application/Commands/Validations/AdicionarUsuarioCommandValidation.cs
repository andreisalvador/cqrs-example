using FluentValidation;

namespace Cqrs.Example.Application.Commands.Validations
{
    public class AdicionarUsuarioCommandValidation : AbstractValidator<AdicionarUsuarioCommand>
    {
        public AdicionarUsuarioCommandValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("O nome não pode ser vazio.");

            RuleFor(c => c.Idade)
                .GreaterThanOrEqualTo((byte)1)
                .WithMessage("A idade não pode ser menor que 1");

            RuleFor(c => c.Sexo)
                .IsInEnum()
                .WithMessage("Sexo inválido.");
        }
    }
}
