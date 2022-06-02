using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using shopApplicationapi.Models;

namespace shopApplicationapi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) { }

        //public DbSet<ShopItem> ShopItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            
            var configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaulConnection"));
        }

        public DbSet<ShopItem> ShopItemDT { get; set; }
    }
}
