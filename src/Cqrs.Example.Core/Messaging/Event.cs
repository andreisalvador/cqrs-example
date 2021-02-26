using MediatR;
using System;

namespace Cqrs.Example.Core.Messaging
{
    public abstract class Event : INotification
    {
        public DateTime Timestamp { get; private set; }
        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}
