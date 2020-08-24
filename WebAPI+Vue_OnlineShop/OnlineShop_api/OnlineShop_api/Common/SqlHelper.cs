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
    public static DataTable ExecuteTable(string cmdText)
    {
      using (SqlConnection con = new SqlConnection(ConStr))
      {
        con.Open();
        SqlCommand cmd = new SqlCommand(cmdText, con);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        // 將從SQL取得的資料塞入DataSet
        sda.Fill(ds);
        return ds.Tables[0];
      }
    }

    // 增刪改都可用此方法
    public static int ExecuteNonQuery(string cmdText)
    {
      using (SqlConnection con = new SqlConnection(ConStr))
      {
        con.Open();
        SqlCommand cmd = new SqlCommand(cmdText, con);
        // 返回受影響的行數
        int rows = cmd.ExecuteNonQuery();
        if(rows <= 0)
        {
          throw new Exception("資料庫執行錯誤");
        }
        return rows;
      }
    }
  }
}
