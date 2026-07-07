using System;
using System.Collections.Generic;

namespace TopDownRPGFramework.Core.Events
{
    public sealed class EventBus : IEventBus
    {
        private readonly Dictionary<Type, Delegate> _handlers = new();
        public void Publish<TEvent>(TEvent eventData) where TEvent : IEvent
        {
            Type eventType = typeof(TEvent);
            if(_handlers.TryGetValue(eventType, out Delegate handlers))
            {
                ((Action<TEvent>)handlers)?.Invoke(eventData);
            }
        }

        public void Subscribe<TEvent>(Action<TEvent> handler) where TEvent : IEvent
        {
            Type eventType = typeof(TEvent);

            if(_handlers.TryGetValue(eventType, out Delegate existingHandlers))
            {
                _handlers[eventType] = Delegate.Combine(existingHandlers, handler);
            }
            else
            {
                _handlers[eventType] = handler;
            }
        }

        public void Unsubscribe<TEvent>(Action<TEvent> handler) where TEvent : IEvent
        {
            Type eventType = typeof(TEvent);
            if( _handlers.TryGetValue(eventType,out Delegate existingHandlers))
            {
                Delegate updateHandlers = Delegate.Remove(existingHandlers, handler);

                if(updateHandlers == null)
                {
                    _handlers.Remove(eventType);
                }
                else
                {
                    _handlers[eventType] = updateHandlers;
                }
            }
        }
    }
}
