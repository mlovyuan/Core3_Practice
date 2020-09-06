using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentPageAPI.Etities
{
    public partial class JobRecruitmentContext : DbContext
    {
        public JobRecruitmentContext()
        {
        }

        public JobRecruitmentContext(DbContextOptions<JobRecruitmentContext> options) : base(options)
        {
        }

        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<Companys> Companys { get; set; }
        public virtual DbSet<Jobs> Jobs { get; set; }
        public virtual DbSet<Requirements> Requirements { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; database=JobRecruitment");
            }
        }
    }
}
