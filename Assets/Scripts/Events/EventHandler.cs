using System;
using System.Collections.Generic;

//TODO: BUSCAR A VER SI HAY LISTA YA ORDENADA POR ENUM DE PRIORIDAD
public class EventHandler
{
    Dictionary<Type, List<OrderedEvent<IGameEvent>>> events;
    public int OwnerId { get; }

    public EventHandler(int ownerId)
    {
        OwnerId = ownerId;
    }

    void Cleanup(Type type)
    {
        throw new NotImplementedException();    
    }

    public void Publish<T>(T data) where T : IGameEvent
    {
        throw new NotImplementedException();
    }

    public void Subscribe<T>(OrderedEvent<T> e) where T : IGameEvent
    {
        throw new NotImplementedException();
    }

    public void Unsubscribe<T>(OrderedEvent<T> e) where T : IGameEvent
    {
        throw new NotImplementedException();
    }
}