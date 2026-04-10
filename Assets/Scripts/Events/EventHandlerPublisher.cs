using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class EventHandlerPublisher
{
    Dictionary<HandlerType, List<EventHandler>> handlers;
    Dictionary<HandlerType, List<OrderedEvent<IGameEvent>>> generalEvents;

    public EventHandlerPublisher()
    {
        handlers = new();
        generalEvents = new();
    }


    public void Publish(HandlerType type, EventHandler handler)
    {
        handlers[type].Add(handler);

        foreach(OrderedEvent e in generalEvents[type])
        {
            handler.Subscribe(e);
        }
    }

    public void Unpublish(HandlerType type, EventHandler handler)
    {
        handlers[type].Remove(handler);
    }

    void AppendEvent<T>(HandlerType type, OrderedEvent<T> e) where T : IGameEvent
    {
        foreach(EventHandler eh in handlers[type])
        {
            eh.Subscribe(e);
        }
    }

    void RemoveEvent<T>(HandlerType type, OrderedEvent<T> e) where T : IGameEvent
    {
        foreach(EventHandler eh in handlers[type])
        {
            eh.Unsubscribe(e);
        }
    }


    public void Subscribe<T>(HandlerType type, OrderedEvent<T> e) where T : IGameEvent
    {
        generalEvents[type].Add(e);
        AppendEvent(type, e);
    }

    public void SubscribeToCurrent<T>(HandlerType type, OrderedEvent<T> e) where T : IGameEvent
    {
        AppendEvent(type, e);
    }


    public void Unsubscribe<T>(HandlerType type, OrderedEvent<T> e) where T : IGameEvent
    {
        generalEvents[type].Remove(e);
        RemoveEvent(e);
    }

    public void UnsubscribeToCurrent<T>(HandlerType type, OrderedEvent<T> e) where T : IGameEvent
    {
        RemoveEvent(e);
    }
}