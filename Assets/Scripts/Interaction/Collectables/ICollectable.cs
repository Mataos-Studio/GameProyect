public interface ICollectable : IInteractable
{
    void OnPickUp(IInteractor whoPickedUp);
    void OnDropOut(IInteractor whoDroppedOut);
}