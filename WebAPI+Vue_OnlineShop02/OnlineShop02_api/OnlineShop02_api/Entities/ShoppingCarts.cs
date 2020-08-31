using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop02_api.Entities
{
    public class ShoppingCarts
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public string Size { get; set; }
        public int ProductId { get; set; }
        public Products Product { get; set; }
    }
}
