using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System;

namespace Cqrs.Example.Core.Messaging
{
    public abstract class Message<TMessage, TMessageResult> : IRequest<TMessageResult>, IBaseRequest
    {
        private readonly AbstractValidator<TMessage> _messageValidator;
        protected Message(AbstractValidator<TMessage> messageValidator)
        {
            _messageValidator = messageValidator;
            Timestamp = DateTime.Now;
        }

        public DateTime Timestamp { get; }
        public ValidationResult ValidationResult { get; set; }

        protected bool IsValid(TMessage message)
        {
            ValidationResult = _messageValidator.Validate(message);
            return ValidationResult.IsValid;
        }

        public abstract bool IsValid();
    }
}
