namespace Domain
{
    public interface IInteracter
    {
        IInteractable Hands { get; set; }
        void ReceivePay(int money);
    }
}
