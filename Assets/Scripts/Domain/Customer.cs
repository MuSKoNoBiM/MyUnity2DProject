using System;

namespace Domain
{
    public class Customer : IInteractable
    {
        private int _moneyToPay = 1;

        public event Action<IInteractable> TakedGoods;

        public int MoneyToPay
        {
            get
            {
                return _moneyToPay;
            }

            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException();

                _moneyToPay = value;
            }
        }

        public void Interact(IInteracter interacter)
        {
            if (interacter is null)
            {
                throw new ArgumentNullException(nameof(interacter));
            }

            if (interacter.Hands == null) return;

            interacter.ReceivePay(_moneyToPay);
            TakedGoods?.Invoke(interacter.Hands);
            interacter.Hands = null;
        }
    }
}
