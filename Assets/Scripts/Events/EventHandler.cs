using System;
using System.Collections.Generic;

//TODO: BUSCAR A VER SI HAY LISTA YA ORDENADA POR ENUM DE PRIORIDAD
public class EventHandler
{
    readonly Dictionary<Type, List<BaseOrderedEvent>> events;
    public int OwnerId { get; }

    public EventHandler(int ownerId)
    {
        OwnerId = ownerId;
        events = new();
    }

    void Cleanup(Type type)
    {
        events[type].Clear();
    }

    public void Publish<T>(T data) where T : IGameEvent
    {
        var e = events[typeof(T)];

        for (int i = 0; i < events.Count; i++)
        {
            e[i].Execute(data);

            if(e[i].EventFinished)
            {
                e.RemoveAt(i);
            }
        }
    }

    public void Subscribe<T>(OrderedEvent<T> e) where T : IGameEvent
    {
        events[typeof(T)].Add(e);
        events[typeof(T)].Sort((a, b) => a.Priority.CompareTo(b.Priority));
    }

    public void Unsubscribe<T>(OrderedEvent<T> e) where T : IGameEvent
    {
        events[typeof(T)].Remove(e);
    }
}