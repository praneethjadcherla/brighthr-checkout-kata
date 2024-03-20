using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.main
{
    public class Checkout : ICheckout
    {
        private Dictionary<string, int> itemsScanned = new Dictionary<string, int>();

        private Dictionary<string, int> prices = new Dictionary<string, int>
        {
          { "A", 50 },
          { "B", 30 },
          { "C", 20 },
          { "D", 15 }

        };

        private Dictionary<string, (int quantity, int price)> specialPrices = new Dictionary<string, (int, int)>
        {
          { "A", (3, 130) },
          { "B", (2, 45) }
        };
        public int GetTotalPrice()
        {
            int totalPrice = 0;
            foreach (var item in itemsScanned)
            {
                string sku = item.Key;
                int quantity = item.Value;

                if (specialPrices.ContainsKey(sku))
                {
                    var offer = specialPrices[sku];
                    int offerQuantity = offer.Item1;
                    int offerPrice = offer.Item2;

                    totalPrice += (quantity / offerQuantity) * offerPrice;
                    totalPrice += (quantity % offerQuantity) * prices[sku];

                }
                else
                {
                    totalPrice += quantity * prices[sku];
                }
            }            

            return totalPrice;
        }

        public void Scan(string item)
        {
            if (string.IsNullOrEmpty(item))
            {
                throw new ArgumentException("Item cannot be null or empty.");
            }

            if (!prices.ContainsKey(item))
            {
                throw new ArgumentException($"Item '{item}' is not available in the price list.");
            }

            if (itemsScanned.ContainsKey(item))
            {
                itemsScanned[item]++;
            }
            else
            {
                itemsScanned[item] = 1;
            }
        }

        
    }
}
