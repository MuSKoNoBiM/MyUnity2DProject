using Domain;

namespace Tests.UnitTests.OwnMoks
{
    public class InteractableMok : IInteractable
    {
        public IInteracter Interacter { get; private set; }

        public void Interact(IInteracter interacter)
        {
            Interacter = interacter;
        }
    }
}
