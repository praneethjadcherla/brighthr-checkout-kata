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
        public int GetTotalPrice()
        {
            int totalprice = 0;
            foreach (var item in itemsScanned)
            {
                string sku = item.Key;
                int quantity = item.Value;

                totalprice += quantity * prices[sku]; 
            }            

            return totalprice;
        }

        public void Scan(string item)
        {
            if (itemsScanned.ContainsKey(item))
            {
                itemsScanned[item]++;
            }
            else
            {
                itemsScanned[item] = 1;
            }
        }

        private Dictionary<string, int> prices = new Dictionary<string, int>
    {
        { "A", 50 },
        { "B", 30 },
        { "C", 20 },
        { "D", 15 }

    };
    }
}
