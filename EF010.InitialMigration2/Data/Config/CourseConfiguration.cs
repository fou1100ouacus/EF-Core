using EF010.InitialMigration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF010.InitialMigration.Data.Config
{
    internal class CourseConfiguration:IEntityTypeConfiguration<Course> 
    {
        public void Configure(EntityTypeBuilder<Course>builder)
        {
            builder.ToTable("Courses");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.CourseName).HasColumnType("VARCHAR").HasMaxLength(100).IsRequired();
            builder.Property(c => c.Price).HasColumnType("decimal(18,2)");
            builder.HasData(loadCourses());
        }
        private static List<Course> loadCourses()
        {
            return new List<Course>
            {
                new Course { Id = 1, CourseName = "C# Programming", Price = 99.99m },
                new Course { Id = 2, CourseName = "ASP.NET Core", Price = 149.99m },
                new Course { Id = 3, CourseName = "Entity Framework Core", Price = 79.99m }
            };
        }
    }
}
