public interface IInteractable : IObject
{
    InteractableType GetType();
    void StartInteraction(IInteractor interactor);
}