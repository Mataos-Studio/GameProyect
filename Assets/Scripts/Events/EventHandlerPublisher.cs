using System.Collections.Generic;

public class EventHandlerPublisher
{
    Dictionary<HandlerType, List<EventHandler>> handlers;
    Dictionary<HandlerType, OrderedEvent<IGameEvent>> generalHandlers;


    public void Publish(HandlerType type, EventHandler handler)
    {
        
    }

    public void Unpublish(HandlerType type, EventHandler handler)
    {
        
    }

    public void Subscribe<T>(HandlerType type, OrderedEvent<T> e) where T : IGameEvent
    {
        
    }

    public void SubscribeToCurrent<T>(HandlerType type, OrderedEvent<T> e) where T : IGameEvent
    {
        
    }

    public void Unsubscribe<T>(HandlerType type, OrderedEvent<T> e) where T : IGameEvent
    {
        
    }

    public void UnsubscribeToCurrent<T>(HandlerType type, OrderedEvent<T> e) where T : IGameEvent
    {
        
    }
}