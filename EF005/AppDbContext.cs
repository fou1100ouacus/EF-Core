using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbContext;
namespace EFCore01
{
    public class AppDbContext:DbContext
    {
        public DbSet<Wallet> Wallets { get; set; } = null! ;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var Configuation = new ConfigurationBuilder()
                .AddJsonFile("appsettingss.json").Build();


            var conecstr = Configuation.GetSection("conecstr").Value;
            optionsBuilder.UseSqlServer(conecstr);


        }
    }
}
