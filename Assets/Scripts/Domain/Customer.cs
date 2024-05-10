using System;

namespace Domain
{
    public class Customer : IInteractable
    {
        public event Action TakedGoods;

        public void Interact(IInteracter interacter)
        {
            if (interacter is null)
            {
                throw new ArgumentNullException(nameof(interacter));
            }

            if (interacter.Hands == null) return;

            interacter.Hands = null;
            TakedGoods?.Invoke();
        }
    }
}
