using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMS.Entities;
using SMS.Domain.Interfaces;
using System.Data.Entity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SMS.Domain
{
    public class BookDBContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Book>().Property(p => p.Price).HasPrecision(18, 2);
            modelBuilder.Entity<Book>().ToTable("Books");
            modelBuilder.Entity<Book>().Property(book => book.MarketArea.Nation).HasColumnName("MarketNation");
            modelBuilder.Entity<Book>().Property(book => book.MarketArea.Province).HasColumnName("MarketProvince");
            modelBuilder.Entity<Book>().Property(book => book.MarketArea.City).HasColumnName("MarketCity");
            modelBuilder.Entity<Book>().HasKey(book => book.BookId);

            modelBuilder.Entity<Book>().Property(book => book.BookId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //modelBuilder.Entity<Book>().HasRequired(book => book.Name);

            base.OnModelCreating(modelBuilder);
        }
    }
}
