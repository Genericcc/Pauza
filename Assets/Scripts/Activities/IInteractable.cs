namespace Activities
{
    public interface IInteractable
    {
        void Interact(Player player);
        bool CanInteract(Player player);
    }
}