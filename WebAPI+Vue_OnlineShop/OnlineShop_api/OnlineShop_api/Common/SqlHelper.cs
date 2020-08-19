using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop_api.Common
{
  public class SqlHelper
  {
    public static string ConStr { get; set; }
    public static DataTable ExecuteTable()
    {
      using (SqlConnection con = new SqlConnection(ConStr))
      {

      }
    }
  }
}
