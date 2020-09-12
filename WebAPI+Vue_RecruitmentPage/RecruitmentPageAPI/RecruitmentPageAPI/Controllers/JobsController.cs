using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecruitmentPageAPI.Etities;
using RecruitmentPageAPI.Models;

namespace RecruitmentPageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly JobRecruitmentContext _context;

        public JobsController(JobRecruitmentContext context) 
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        /// <summary>
        /// 取得所有工作
        /// </summary>
        /// <returns></returns>
        // GET: api/Jobs
        [HttpGet]
        public IEnumerable<Jobs> Get()
        {
            return new JobsVM(_context).GetJobs();
        }

        //// GET: api/Jobs/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Jobs
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Jobs/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
