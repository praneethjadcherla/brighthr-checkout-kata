using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.main;
using NUnit.Framework;

namespace ClassLibrary.test
{
    [TestFixture]
    public class CheckoutTests
    {
        [Test]
        public void GetTotalPrice_ReturnsZero_WhenNoItemsScanned()
        {
            // Arrange
            var checkout = new Checkout();

            // Act
            var totalPrice = checkout.GetTotalPrice();

            // Assert
            Assert.That(totalPrice, Is.EqualTo(0));
        }

        [Test]
        public void GetTotalPrice_WhenAItemIsScanned()
        {   
            var checkout = new Checkout();
            checkout.Scan("A");

            var totalPrice = checkout.GetTotalPrice();
            
            Assert.That(totalPrice, Is.EqualTo(50));
        }

        [Test]
        public void GetTotalPrice_WhenDifferentItemAreScanned()
        {
            var checkout = new Checkout();
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("C");
            checkout.Scan("D");

            var totalPrice = checkout.GetTotalPrice();

            Assert.That(totalPrice, Is.EqualTo(115));
        }

        [Test]
        public void GetTotalPriceOfSpecialPriceItem_A()
        {
            var checkout = new Checkout();
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");
  
            var totalPrice = checkout.GetTotalPrice();

            Assert.That(totalPrice, Is.EqualTo(130));
        }

        [Test]
        public void GetTotalPriceOfSpecialPriceItem_B()
        {
            var checkout = new Checkout();
            checkout.Scan("B");
            checkout.Scan("B");

            var totalPrice = checkout.GetTotalPrice();


            Assert.That(totalPrice, Is.EqualTo(45));
        }

        [Test]
        public void GetTotalPrice_WhenbothSpecialOfferItem_And_NoOfferItem_Scanned()
        {
            var checkout = new Checkout();
            checkout.Scan("B");
            checkout.Scan("A");
            checkout.Scan("B");

            var totalPrice = checkout.GetTotalPrice();


            Assert.That(totalPrice, Is.EqualTo(95));
        }

        [Test]
        public void GetTotalPrice_CombinationOfMultipleOffers()
        {
            var checkout = new Checkout();
            checkout.Scan("B");
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("B");
            checkout.Scan("B");
            checkout.Scan("D");
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("C");

            var totalPrice = checkout.GetTotalPrice();


            Assert.That(totalPrice, Is.EqualTo(335));
        }

        [Test]
        public void Scan_ThrowsException_WhenItemIsNull()
        {
            var checkout = new Checkout();

            Assert.Throws<ArgumentException>(() => checkout.Scan(null));
        }

        [Test]
        public void Scan_ThrowsException_WhenItemIsEmpty()
        {
            var checkout = new Checkout();

            Assert.Throws<ArgumentException>(() => checkout.Scan(""));
        }
    }
}
