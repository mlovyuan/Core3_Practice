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
  }
}
