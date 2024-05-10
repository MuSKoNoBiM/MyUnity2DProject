using System;

namespace Domain
{
    public class Clicker : IInteracter
    {
        private IPhysics _physics;
        private IInteractable _hands;

        public event Action<IInteractable> Taked;
        public event Action Given;

        public Clicker(IPhysics physics)
        {
            _physics = physics ?? throw new ArgumentNullException(nameof(physics));
        }

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

        public void OnClick()
        {
            if (!_physics.TryRaycast(out IInteractable interactable)) return;

            interactable.Interact(this);
        }
    }
}
