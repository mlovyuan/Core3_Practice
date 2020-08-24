using OnlineShop_api.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop_api.Models
{
  public class ShoppingCart
  {
    public int Id { get; set; }
    public int count { get; set; }
    public int ProductId { get; set; }

    public static int AddCart(int pid, int count)
    {
      return SqlHelper.ExecuteNonQuery($"insert into ShoppingCarts(Count, ProductId) values('{count}', '{pid}')");
    }
  }
}
