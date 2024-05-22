using Domain;
using NUnit.Framework;
using System;
using Tests.UnitTests.OwnMoks;

namespace Tests.UnitTests
{
    public class ClickerTests
    {
        private Clicker _clicker;

        [SetUp]
        public void SetUp()
        {
            _clicker = new Clicker();
        }

        [Test]
        public void OnClick_ArgumentIsNull_ThrowException()
        {
            Assert.Throws<ArgumentNullException>
                (() => _clicker.OnClick(null));
        }

        [Test]
        public void OnClick_ArgumentIsMok_CalledInteractMethodWithArgumentIsThisClicker()
        {
            var interactable = new InteractableMok();

            _clicker.OnClick(interactable);
            Assert.AreEqual(_clicker, interactable.Interacter);
        }

        [Test]
        public void SetHands_ArgumentIsMok_CalledEventTakedAndHandsIsThisMok()
        {
            var interactable = new InteractableMok();
            bool calledEvent = false;

            _clicker.Taked += (arg) =>
            {
                calledEvent = true;
                Assert.AreEqual(arg, interactable);
            };

            _clicker.Hands = interactable;

            Assert.IsTrue(calledEvent);
            Assert.AreEqual(interactable, _clicker.Hands);
        }

        [Test]
        public void SetHands_ArgumentIsNull_CalledEventGivenAndHandsIsNull()
        {
            bool calledEvent = false;

            _clicker.Given += () => calledEvent = true;
            _clicker.Hands = null;

            Assert.IsTrue(calledEvent);
            Assert.IsNull(_clicker.Hands);
        }
    }
}
