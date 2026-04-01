using System;
using UnityEngine;

public class OrderedEvent<T> where T : IGameEvent
{
    public PriorityType Priority { get; }
    public int TriggerTimes { get; set; }
    Action<T> Callback { get; }

    public OrderedEvent(PriorityType priority, int triggerTimes, Action<T> callback)
    {
        Priority = priority;
        TriggerTimes = triggerTimes;
        Callback = callback;
    }

    public void Execute(T data) => Callback.Invoke(data);
}