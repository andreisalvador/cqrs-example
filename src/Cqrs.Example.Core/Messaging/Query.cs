using FluentValidation;

namespace Cqrs.Example.Core.Messaging
{
    public abstract class Query<TQuery, TQueryResult> : Message<TQuery, TQueryResult>
    {
        protected Query(AbstractValidator<TQuery> queryValidator) : base(queryValidator) { }
    }
}
