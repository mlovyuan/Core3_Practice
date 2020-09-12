using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RecruitmentPageAPI.Etities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentPageAPI.Models
{
    public class JobsVM
    {
        public int Id { get; set; }
        public string JobName { get; set; }
        public string JobPay { get; set; }
        public string Welfare { get; set; }
        public string Education { get; set; }
        public string WorkExperience { get; set; }
        public int WorkPlace { get; set; }
        public string WorkArea { get; set; }
        public DateTime? PublishTime { get; set; }
        public string PositionInfo { get; set; }
        public int? CompanyId { get; set; }
        public virtual Companys Company { get; set; }
        public virtual Cities City { get; set; }

        private readonly JobRecruitmentContext _context;
        public JobsVM(JobRecruitmentContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public List<Jobs> GetJobs()
        {
            var jobs = _context.Jobs.Include(m => m.Company).Include(m => m.City).ToList();
            // 設定JsonSerialize時可以套用的設定，首項為若JSON格式層次因為有資料重複導致太深，忽略
            // 後項為格式不整理
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.None
            };
            return _context.Jobs.Include(m => m.Company).Include(m => m.City).ToList();
        }
    }
}
