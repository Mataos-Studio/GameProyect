
public abstract class BaseOrderedEvent
{
    public BaseOrderedEvent(PriorityType priority, int triggerTimes)
    {
        Priority = priority;
        TriggerCounter = 0;
        TriggerTimes = triggerTimes;
    }

    public PriorityType Priority { get; }
    public int TriggerTimes { get; set; }
    public int TriggerCounter { get; protected set; }

    public bool EventFinished { get => TriggerCounter >= TriggerTimes; }

    

    public abstract void Execute(IGameEvent data);
}