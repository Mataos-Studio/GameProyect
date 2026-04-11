using System.Collections.Generic;

public class EventHandlerPublisher
{
    readonly Dictionary<HandlerType, List<EventHandler>> handlers;
    readonly Dictionary<HandlerType, List<BaseOrderedEvent>> generalEvents;

    public EventHandlerPublisher()
    {
        handlers = new();
        generalEvents = new();
    }


    public void Publish(HandlerType type, EventHandler handler)
    {
        handlers[type].Add(handler);

        foreach(OrderedEvent<IGameEvent> e in generalEvents[type])
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
        RemoveEvent(type, e);
    }

    public void UnsubscribeToCurrent<T>(HandlerType type, OrderedEvent<T> e) where T : IGameEvent
    {
        RemoveEvent(type, e);
    }
}