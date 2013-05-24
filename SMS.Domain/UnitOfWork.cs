using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMS.Domain.Repositories;
using SMS.Entities;

namespace SMS.Domain
{
    public class UnitOfWork
    {
        private SMSContext context = new SMSContext();
        private GenericRepository<Book> bookRepository;
        public GenericRepository<Book> BookRepository
        {
            get
            {
                if (this.bookRepository == null)
                {
                    this.bookRepository = new GenericRepository<Book>(context);
                } 
                return bookRepository;
            }
        }

        public void Save() { context.SaveChanges(); }   
     
        private bool disposed = false; 

        protected virtual void Dispose(bool disposing) { 
            if (!this.disposed) { 
                if (disposing) { context.Dispose(); } 
            } 
            this.disposed = true; 
        }       
 
        public void Dispose() { 
            Dispose(true); 
            GC.SuppressFinalize(this); 
        }
    }
}
