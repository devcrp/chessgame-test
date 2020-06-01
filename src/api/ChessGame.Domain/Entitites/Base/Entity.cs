using ChessGame.Domain.Events.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGame.Domain.Entitites.Base
{
    public class Entity
    {
        public List<KeyValuePair<Type, IDomainEventHandler>> Handlers { get; } = new List<KeyValuePair<Type, IDomainEventHandler>>();
        public List<IDomainEvent> Events { get; } = new List<IDomainEvent>();

        protected void AddDomainEvent(IDomainEvent @event) => Events.Add(@event);
        public void AddDomainEventHandler<T>(IDomainEventHandler handler) => Handlers.Add(new KeyValuePair<Type, IDomainEventHandler>(typeof(T), handler));

        public void DispatchEvents()
        {
            foreach (IDomainEvent @event in Events)
            {
                Type eventType = @event.GetType();

                var handlers = Handlers.Where(handler => handler.Key == eventType).ToList();
                foreach (KeyValuePair<Type, IDomainEventHandler> handler in handlers)
                {
                    handler.Value.Handle(@event);
                }
            }

            Events.Clear();
        }
    }
}
