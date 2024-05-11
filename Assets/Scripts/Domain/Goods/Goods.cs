using System;

namespace Domain
{
    public class Goods : IInteractable
    {
        private IInteractable thisGoods;

        public Goods()
        {
            thisGoods = this;
        }

        public Goods(IInteractable @this)
        {
            thisGoods = @this ?? throw new ArgumentNullException(nameof(@this));
        }

        public void Interact(IInteracter interacter)
        {
            if (interacter is null)
            {
                throw new ArgumentNullException(nameof(interacter));
            }

            interacter.Hands = thisGoods;
        }
    }
}
