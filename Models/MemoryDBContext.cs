using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudioMVC.Models
{
    public class MemoryDBContext: DbContext
    {
        public DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=sqlitedemo.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.sno)
                    .HasName("key_constraint");

                entity.ToTable("PEOPLE");

                entity.Property(e => e.sno)
                    .HasColumnName("SNO")
                    .HasColumnType("NUMBER(6)")
                    .ValueGeneratedNever();

                entity.Property(e => e.city)
                    .IsRequired()
                    .HasColumnName("CITY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

        }
    }
}

