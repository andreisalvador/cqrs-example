using FluentValidation;

namespace Cqrs.Example.Application.Queries.Validations
{
    public class ObterUsuariosAtivosPorNomeIdadeQueryValidation : AbstractValidator<ObterUsuariosAtivosPorNomeIdadeQuery>
    {
        public ObterUsuariosAtivosPorNomeIdadeQueryValidation()
        {
            RuleFor(q => q.Nome)
                .NotEmpty()
                .WithMessage("O nome é obrigatório para a consulta.");

            RuleFor(q => q.Idade)
                .GreaterThanOrEqualTo((byte)1)
                .WithMessage("A idade precisa ser maior quer zero.");
        }
    }
}
