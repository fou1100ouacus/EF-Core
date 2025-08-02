using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCORE2
{
    internal class appDbContext:DbContext
    {

       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlServer("Data Source=.;initial catalog =DBCore ;Integrated Security=True;" +
           " Trust Server Certificate=True;" );
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Employee>().HasIndex(b=>b.email);


        //    //modelBuilder.Entity<AuditEntry>();
        //    ////new taskenityconfiguration
        //    //modelBuilder.Entity<task>().ToTable("tasks", b => b.ExcludeFromMigrations());
        //    //modelBuilder.Entity<task>().Property(b => b.name).HasColumnName("nametask");
        }



        public DbSet<Employee> Employees { get; set; }
        public DbSet<task> tasks { get; set; }


        //// public DbSet<post> posts { get; set; }




    }
}
