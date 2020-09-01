using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop02_api.Models.ShoppingCartsDto
{
    public class AddCartInput
    {
        public int Count { get; set; }
        public string Size { get; set; }
        public int ProductId { get; set; }
    }
}
