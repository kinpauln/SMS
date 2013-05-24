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
    public class UserDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserDBContext() : base("name=SMSDbConnString") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Book>().Property(p => p.Price).HasPrecision(18, 2);
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>().HasKey(user => user.Id);

            modelBuilder.Entity<User>().Property(user => user.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //modelBuilder.Entity<Book>().HasRequired(book => book.Name);

            base.OnModelCreating(modelBuilder);
        }
    }
}
