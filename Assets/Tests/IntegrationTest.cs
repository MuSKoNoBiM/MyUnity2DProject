using Domain;
using NUnit.Framework;

namespace Tests.IntegrationTests
{
    public class IntegrationTest
    {
        [Test]
        public void Method()
        {
            bool eventTest = true;

            var clicker = new Clicker();
            var goods = new Goods();
            var customer = new Customer();

            OnClickAtCustomer();
            OnClickAtGoods();
            OnClickWithGoodsAtCustomer();

            void OnClickAtCustomer()
            {
                Assert.IsNull(clicker.Hands);

                clicker.Taked += SetEventTest;
                customer.TakedGoods += SetEventTest;
                clicker.OnClick(customer);

                Assert.IsTrue(eventTest);
                Assert.IsNull(clicker.Hands);
            }

            void OnClickAtGoods()
            {
                eventTest = false;
                clicker.OnClick(goods);

                Assert.IsTrue(eventTest);
                Assert.AreEqual(goods, clicker.Hands);
            }

            void OnClickWithGoodsAtCustomer()
            {
                bool clickerEventTest = false;

                eventTest = false;
                clicker.Given += () => clickerEventTest = true;
                clicker.OnClick(customer);

                Assert.IsTrue(eventTest);
                Assert.IsTrue(clickerEventTest);
                Assert.IsNull(clicker.Hands);
            }

            void SetEventTest(IInteractable interactable)
            {
                eventTest = !eventTest;
            }
        }
    }
}
