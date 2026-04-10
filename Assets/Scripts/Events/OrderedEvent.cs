using System;
using UnityEngine;

public class OrderedEvent<T> where T : IGameEvent
{
    public PriorityType Priority { get; }
    public int TriggerTimes { get; set; }
    public int TriggerCounter { get; private set; }

    public bool EventFinished { get => TriggerCounter >= TriggerTimes; }
    Action<T> Callback { get; }

    public OrderedEvent(PriorityType priority, int triggerTimes, Action<T> callback)
    {
        Priority = priority;
        TriggerTimes = triggerTimes;
        Callback = callback;
        TriggerCounter = 0;
    }

    public void Execute(T data)
    {
        Callback.Invoke(data);
        TriggerCounter++;
    }
}