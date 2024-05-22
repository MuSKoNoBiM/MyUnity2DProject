using Domain;
using NUnit.Framework;
using System;
using Tests.UnitTests.OwnMoks;

namespace Tests.UnitTests
{
    public class CustomerTests
    {
        private Customer _customer;

        [SetUp]
        public void SetUp()
        {
            _customer = new Customer();
        }

        [Test]
        public void Interact_ArgumentIsNull_ThrowException()
        {
            Assert.Throws<ArgumentNullException>
                (() => _customer.Interact(null));
        }

        [Test]
        public void Interact_ArgumentIsMokWithHandsIsNull_DoNothing()
        {
            var interacter = new InteracterMok();
            bool calledEvent = false;

            interacter.Hands = null;

            _customer.TakedGoods += (arg) =>
            {
                calledEvent = true;
                Assert.Equals(interacter, arg);
            };

            _customer.Interact(interacter);

            Assert.IsNull(interacter.Hands);
            Assert.IsFalse(calledEvent);
        }

        [Test]
        public void Interact_ArgumentIsMokWithHandsIsMok_SetThisHandsToNull()
        {
            var interactable = new InteractableMok();
            var interacter = new InteracterMok();
            bool calledEvent = false;

            interacter.Hands = interactable;
            _customer.TakedGoods += (arg) => calledEvent = true;

            _customer.Interact(interacter);

            Assert.IsNull(interacter.Hands);
            Assert.IsTrue(calledEvent);
        }
    }
}
