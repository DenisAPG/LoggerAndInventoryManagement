using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LoggerAndInventoryManagement.Core.InventoryManagement
{
    public class InventoryManagement
    {
        public enum SortOrder{
            ASCENDING,
            DESCENDING
        }

        public enum SortKey
        {
            NAME,
            PRICE,
            STOCK,
        }


        public static List<Product> SortProducts(List<Product> products, SortKey productKey, SortOrder sortOrder)
        {
            switch (productKey)
            {
                case SortKey.NAME:
                    return sortOrder == SortOrder.ASCENDING ? products.OrderBy(p => p.Name).ToList() :
                        products.OrderByDescending(p => p.Name).ToList();
                case SortKey.PRICE:
                    return sortOrder == SortOrder.ASCENDING ? products.OrderBy(p => p.Price).ToList() :
                        products.OrderByDescending(p => p.Price).ToList();
                default: 
                    return sortOrder == SortOrder.ASCENDING ? products.OrderBy(p => p.Stock).ToList() :
                        products.OrderByDescending(p => p.Stock).ToList();

            }
        }
    }
}
