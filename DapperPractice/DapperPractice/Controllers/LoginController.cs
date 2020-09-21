using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperPractice.DAL;
using DapperPractice.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpGet("{u}/{p}")]
        public Users Get(string userName, string password)
        {
            return new UserDAL().GetUserByLogin(userName, password);
        }
    }
}