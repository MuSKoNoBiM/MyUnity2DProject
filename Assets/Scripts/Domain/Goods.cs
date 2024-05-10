using System;

namespace Domain
{
    public class Goods : IInteractable
    {
        public void Interact(IInteracter interacter)
        {
            if (interacter is null)
            {
                throw new ArgumentNullException(nameof(interacter));
            }

            interacter.Hands = this;
        }
    }
}
