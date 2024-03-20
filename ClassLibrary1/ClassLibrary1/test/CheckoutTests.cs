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
    }
}
