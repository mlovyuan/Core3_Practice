using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperPractice.Entities
{
    public class Users : BaseEntity
    {
        public string UserNumber { get; set; }
        public string UserName { get; set; }
        public int UserLevel { get; set; }
        public string Password { get; set; }
    }
}
