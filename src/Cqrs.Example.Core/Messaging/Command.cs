using FluentValidation;
using FluentValidation.Results;

namespace Cqrs.Example.Core.Messaging
{
    public abstract class Command<TCommand> : Message<TCommand, ValidationResult>
    {   
        protected Command(AbstractValidator<TCommand> commandValidator) : base(commandValidator) { }

    }
}
