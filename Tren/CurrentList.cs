using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tren
{
    internal class CurrentList
    {
        public static List<Products> products;
        public static TreningDemoEntities db = new TreningDemoEntities();
        public static decimal? priceTotal = 0; // итоговая цена корзины
        public static int discountTotal = 0; // итоговая скидка
        public static List<Products> basketProducts = new List<Products>();
    }
}
