namespace Backend.Object.Item
{
    public interface IInteractable
    {
        void Interact();

        string GetInteractPrompt();
    }
}
