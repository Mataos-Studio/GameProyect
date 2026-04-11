using System;
using UnityEngine;
public class OrderedEvent<T> : BaseOrderedEvent  where T : IGameEvent
{
    Action<T> Callback { get; }

    public OrderedEvent(PriorityType priority, int triggerTimes, Action<T> callback)
    : base(priority, triggerTimes)
    {
        Callback = callback;
    }

    public override void Execute(IGameEvent data)
    {
        Callback.Invoke((T)data);
        TriggerCounter++;
    }
}
