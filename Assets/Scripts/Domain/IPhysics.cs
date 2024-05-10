namespace Domain
{
    public interface IPhysics
    {
        bool TryRaycast(out IInteractable interactable);
    }
}
