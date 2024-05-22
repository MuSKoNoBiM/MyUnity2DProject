using Domain;
using NUnit.Framework;
using System;
using Tests.UnitTests.OwnMoks;

namespace Tests.UnitTests
{
    public class GoodsTests
    {
        [Test]
        public void Constructor_ArgumentIsNull_ThrowException()
        {
            Assert.Throws<ArgumentNullException>
                (() => new Goods(null));
        }

        [Test]
        public void Interact_ArgumentIsNull_ThrowException()
        {
            var goods = new Goods();

            Assert.Throws<ArgumentNullException>
                (() => goods.Interact(null));
        }

        [Test]
        public void Interact_ArgumentIsMok_ThisMokHandsIsThisGoods()
        {
            var goods = new Goods();
            var interacter = new InteracterMok();

            goods.Interact(interacter);

            Assert.AreEqual(goods, interacter.Hands);
        }

        [Test]
        public void Constructor_ArgumentIsMok1_Interact_ArgumentIsMok2_Mok2HandsIsMok1()
        {
            var interactable = new InteractableMok();
            var goods = new Goods(interactable);
            var interacter = new InteracterMok();

            goods.Interact(interacter);

            Assert.AreEqual(interactable, interacter.Hands);
        }
    }
}
