using MediatR;
using System;

namespace Cqrs.Example.Core.Messaging
{
    public abstract class Query<TQueryResult> : IRequest<TQueryResult>
    {
        public DateTime Timestamp { get; private set; }
        public Query()
        {
            Timestamp = DateTime.Now;
        }
    }
}
