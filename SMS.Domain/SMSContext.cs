using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMS.Entities;
using SMS.Domain.Interfaces;
using System.Data.Entity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Infrastructure;

namespace SMS.Domain
{
    public class SMSContext : DbContext
    {
        private readonly static string CONNECTION_STRING = "name=SMSDbConnString";
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

        public SMSContext()
            : base(CONNECTION_STRING)//不写这个  默认的就是SMSContext        
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // 移除复数表名的契约 
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // 防止黑幕交易 要不然每次都要访问 EdmMetadata这个表
            modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
            
            // 书籍
            modelBuilder.Entity<Book>().ToTable("Books");
            modelBuilder.Entity<Book>().Property(book => book.MarketArea.Nation).HasColumnName("MarketNation");
            modelBuilder.Entity<Book>().Property(book => book.MarketArea.Province).HasColumnName("MarketProvince");
            modelBuilder.Entity<Book>().Property(book => book.MarketArea.City).HasColumnName("MarketCity");
            modelBuilder.Entity<Book>().HasKey(book => book.BookId);
            modelBuilder.Entity<Book>().Property(book => book.BookId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //modelBuilder.Entity<Book>().HasRequired(book => book.Name);

            // 用户表
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>().HasKey(user => user.Id);

            modelBuilder.Entity<User>().Property(user => user.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            base.OnModelCreating(modelBuilder);
        }
    }
}
