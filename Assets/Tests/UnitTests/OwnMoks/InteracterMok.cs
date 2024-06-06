using Domain;

namespace Tests.UnitTests.OwnMoks
{
    public class InteracterMok : IInteracter
    {
        public IInteractable Hands { get; set; }

        public void ReceivePay(int money)
        {
            return;
        }
    }
}
