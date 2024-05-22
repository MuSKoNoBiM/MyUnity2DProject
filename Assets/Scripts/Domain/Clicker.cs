using System;

namespace Domain
{
    public class Clicker : IInteracter
    {
        private IInteractable _hands;

        public event Action<IInteractable> Taked;
        public event Action Given;

        public IInteractable Hands
        {
            get
            {
                return _hands;
            }

            set
            {
                _hands = value;

                if (value != null)
                    Taked?.Invoke(value);
                else
                    Given?.Invoke();
            }
        }

        public void OnClick(IInteractable interactable)
        {
            if (interactable is null)
            {
                throw new ArgumentNullException(nameof(interactable));
            }

            interactable.Interact(this);
        }
    }
}
