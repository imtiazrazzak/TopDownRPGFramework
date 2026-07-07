using System;

namespace TopDownRPGFramework.Core.Events
{
    public interface IEventBus
    {
        void Publish<TEvent>(TEvent eventData) where TEvent : IEvent;
        void Subscribe<TEvent>(Action<TEvent> handler) where TEvent : IEvent;

        void Unsubscribe<TEvent>(Action<TEvent> handler) where TEvent : IEvent;
    }
}
