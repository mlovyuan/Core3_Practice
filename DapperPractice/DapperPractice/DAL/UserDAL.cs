using DapperPractice.Entities;
using DapperPractice.SqlContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperPractice.DAL
{
    public class UserDAL
    {
        DapperHelper _db = new DapperHelper();
        public Users GetUserByLogin(string userName, string password)
        {
            string sql = "Select * from Users where UserName = @userName and Password = @password";
            // new 裡面本來應該要是{ userName : userName, password : password }，跟ES6的object有點像
            // 前為後端屬性名稱，後為變數，但因要傳入的值在sql中採用變數方式，所以可以用變數名稱直接簡寫
            var user = _db.QueryFirst<Users>(sql, new { userName, password });

            if(user == null)
            {
                // 看方法返回值是值類型還是引用類型，若是值類型就是0，引用則為null
                return default;
            }
            return user;
        }
    }
}
