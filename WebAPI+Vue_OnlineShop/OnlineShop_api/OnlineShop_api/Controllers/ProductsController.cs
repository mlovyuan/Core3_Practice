using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop_api.Models;

namespace OnlineShop_api.Controllers
{
  [EnableCors("any")]
  [Route("api/[controller]/[action]")]
  [ApiController]
  public class ProductsController : ControllerBase
  {
    public List<Product> GetProducts()
    {
      List<Product> productList = Product.GetProductList();
      return productList;
    }

    // 前端參數設計名稱為pid，後端這邊也要用同樣名稱才收的到
    public Product GetProductById(string pid)
    {
      // 做前端傳值的驗證，增加程式容錯性，也可用正則表達判斷
      int id = -1;
      try
      {
        id = Convert.ToInt32(pid);
      }
      catch (Exception)
      {
        HttpContext.Response.StatusCode = 205;
        return default;
      }
      Product product = Product.GetProductById(id);
      return product;
    }

    public int AddCart(int productid, int count)
    {
      int rows = ShoppingCart.AddCart(productid, count);
      return rows;
    }
  }
}
