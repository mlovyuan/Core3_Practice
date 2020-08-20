using OnlineShop_api.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop_api.Models
{
  public class Product
  {
    public int Id { get; set; }
    public string ProductName { get; set; }
    public string ProductImgUrl { get; set; }
    public string ProductDetailImgUrl { get; set; }
    public decimal Price { get; set; }

    public static List<Product> GetProductList()
    {
      DataTable dt = SqlHelper.ExecuteTable("select * from Products");
      List<Product> products = new List<Product>();
      for(int i =0; i < dt.Rows.Count; i++)
      {
        products.Add(ToModel(dt.Rows[i]));
      }
      return products;
    }

    private static Product ToModel(DataRow dr)
    {
      Product product = new Product();
      product.Id = (int)dr["Id"];
      product.ProductName = dr["ProductName"].ToString();
      product.ProductImgUrl = dr["ProductImgUrl"].ToString();
      product.ProductDetailImgUrl = dr["ProductDetailImgUrl"].ToString();
      product.Price = (decimal)dr["Price"];
      return product;
    }
  }
}
