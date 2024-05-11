using System;

namespace Domain
{
    public class Customer : IInteractable
    {
        public event Action<IInteractable> TakedGoods;

        public void Interact(IInteracter interacter)
        {
            if (interacter is null)
            {
                throw new ArgumentNullException(nameof(interacter));
            }

            if (interacter.Hands == null) return;

            TakedGoods?.Invoke(interacter.Hands);
            interacter.Hands = null;
        }
    }
}
