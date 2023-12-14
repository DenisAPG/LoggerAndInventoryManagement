using LoggerAndInventoryManagement.Core.InventoryManagement;
using static LoggerAndInventoryManagement.Core.InventoryManagement.InventoryManagement;

namespace LoggerAndInventoryManagement.Tests.InventoryManagementTests
{
    [TestClass]
    public class InventoryManagementUnitTests
    {

        protected List<Product> products;


        [TestInitialize]
        public void TestInitialize()
        {
            products = new List<Product>()
            {
                new Product{Name ="Product A", Price = 100m, Stock=5},
                new Product{Name ="Product B", Price = 200m, Stock=3},
                new Product{Name ="Product C", Price = 50m, Stock=10},
                new Product{Name ="Product D", Price = 10m, Stock=1}
            };
        }

        [TestMethod]
        public void SortProducts_ByNameKey_Ascending()
        {
            var orderedList = InventoryManagement.SortProducts(products, SortKey.NAME, SortOrder.ASCENDING);

            for (int i = 0; i < orderedList.Count - 1; i++)
            {
                string current = orderedList[i].Name;
                string next = orderedList[i + 1].Name;
                Console.WriteLine("Comparing {" + current + "} to  {" + next + "}");
                Console.WriteLine("Comparison Result: " + String.Compare(current, next, true));
                Assert.IsTrue(String.Compare(current, next, true) <= 0,
                    "Name" + current + " should precede Name " + next + "!");
            }   
        }

        [TestMethod]
        public void SortProducts_ByNameKey_Descending()
        {
            var orderedList = InventoryManagement.SortProducts(products, SortKey.NAME, SortOrder.DESCENDING);

            for (int i = 0; i < orderedList.Count - 1; i++)
            {
                string current = orderedList[i].Name;
                string next = orderedList[i + 1].Name;
                Console.WriteLine("Comparing {" + current + "} to  {" + next + "}");
                Assert.IsTrue(String.Compare(current, next, true) >= 0,
                    "Name" + current + " should succeed Name " + next + "!");
            }
        }

        [TestMethod]
        public void SortProducts_ByPriceKey_Ascending()
        {
            var orderedList = InventoryManagement.SortProducts(products, SortKey.PRICE, SortOrder.ASCENDING);

            for (int i = 0; i < orderedList.Count - 1; i++)
            {
                var current = orderedList[i].Price;
                var next = orderedList[i + 1].Price;
                Console.WriteLine("Comparing {" + current + "} to  {" + next + "}");
                Assert.IsTrue(current <= next,
                    "Price" + current + " should precede Price " + next + "!");
            }

        }

        [TestMethod]
        public void SortProducts_ByPriceKey_Descending()
        {
            var orderedList = InventoryManagement.SortProducts(products, SortKey.PRICE, SortOrder.DESCENDING);

            for (int i = 0; i < orderedList.Count - 1; i++)
            {
                var current = orderedList[i].Price;
                var next = orderedList[i + 1].Price;
                Console.WriteLine("Comparing {" + current + "} to  {" + next + "}");
                Assert.IsTrue(current >= next,
                    "Price" + current + " should succeed Price " + next + "!");
            }
        }

        [TestMethod]
        public void SortProducts_ByStockKey_Ascending()
        {
            var orderedList = InventoryManagement.SortProducts(products, SortKey.STOCK, SortOrder.ASCENDING);

            for (int i = 0; i < orderedList.Count - 1; i++)
            {
                var current = orderedList[i].Stock;
                var next = orderedList[i + 1].Stock;
                Console.WriteLine("Comparing {" + current + "} to  {" + next + "}");
                Assert.IsTrue(current <= next,
                    "Stock" + current + " should precede Stock " + next + "!");
            }
        }

        [TestMethod]
        public void SortProducts_ByStockKey_Descending()
        {
            var orderedList = InventoryManagement.SortProducts(products, SortKey.STOCK, SortOrder.DESCENDING);

            for (int i = 0; i < orderedList.Count - 1; i++)
            {
                var current = orderedList[i].Stock;
                var next = orderedList[i + 1].Stock;
                Console.WriteLine("Comparing {" + current + "} to  {" + next + "}");
                Assert.IsTrue(current >= next,
                    "Stock" + current + " should precede Stock " + next + "!");
            }
        }


    }
}