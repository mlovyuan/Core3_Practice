using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop02_api.Entities
{
    public class Products
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public decimal OrgPrice { get; set; }
        public string Decoration { get; set; }
        public string Size { get; set; }
        public int ClickTimes { get; set; }
        public int SaleTimes { get; set; }
        public bool IdDel { get; set; }
    }
}
