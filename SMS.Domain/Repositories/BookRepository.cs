using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Configuration;
using SMS.Entities;
using SMS.Domain.Interfaces;
using System.Data.Entity.Infrastructure;

namespace SMS.Domain.Repositories
{
    public class BookRepository : IBookRepository, IDisposable
    {

        BookDBContext context;

        public BookRepository()
        {
            context = new BookDBContext();
        }

        public BookRepository(BookDBContext context)
        {
            this.context = context;
        }

        public IQueryable<Book> Get() { 
            //return context.Books.AsQueryable().OrderBy(b=>b.BookId); 
            return context.Books.AsQueryable(); 
        }

        public Book GetByID(int id)
        { 
            return context.Books.Find(id); 
        }

        public void Insert(Book book) { 
            context.Books.Add(book); 
        }

        public void Delete(int bookID)
        {
            Book student = context.Books.Find(bookID);
            context.Books.Remove(student);
        }

        public void Update(Book book)
        {
            context.Entry(book).State = System.Data.EntityState.Modified; 
        }

        public void Save() { context.SaveChanges(); }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            } this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}