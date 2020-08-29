using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop02_api.Entities
{
    public class OnlineShopApiContext:DbContext
    {
        public OnlineShopApiContext() { }
        public OnlineShopApiContext(DbContextOptions<OnlineShopApiContext> dbContextOptions):base(dbContextOptions)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 檢查optionsBuilder是否已被配置
            if (!optionsBuilder.IsConfigured)
            {
                // 沒被配置就要做一個映射的DB
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; database = OnlineShop02");
            }
        }

        // 到資料庫生成的表也會叫Products
        public DbSet<Products> Products { get; set; }

        // 生成時順便對table做一些配置
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 變成ps.Products
            modelBuilder.Entity<Products>().ToTable("Products", "ps");
            modelBuilder.Entity<Products>(entity => entity.Property((e) => e.ImageUrl).HasMaxLength(500));
            base.OnModelCreating(modelBuilder);
        }
    }
}
