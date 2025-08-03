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
    internal class InstructorConfiguration
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.ToTable("Instructors");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.FName).HasColumnType("VARCHAR").HasMaxLength(100).IsRequired();
            builder.Property(c => c.LName).HasColumnType("VARCHAR").HasMaxLength(100).IsRequired();

            builder.HasData(loadInstructors());
        }
        private static List<Instructor> loadInstructors()
        {
            return new List<Instructor>
            {
                new Instructor { Id = 1, FName = "Ahmed",LName= "ad"},
                new Instructor { Id = 2, FName = "Ali" , LName= "aJHJKd"},
                new Instructor { Id = 3, FName = "aya",LName= "JHJHJK" }
            };
        }
    }
}
