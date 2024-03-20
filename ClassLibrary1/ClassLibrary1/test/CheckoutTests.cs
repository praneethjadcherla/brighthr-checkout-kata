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
    }
}
