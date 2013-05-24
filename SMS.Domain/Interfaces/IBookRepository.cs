using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMS.Entities;

namespace SMS.Domain.Interfaces {
    public interface IBookRepository:IDisposable
    {
        IQueryable<Book> Get();
        Book GetByID(int studentId);
        void Insert(Book book);
        void Delete(int bookID);
        void Update(Book book); 
        void Save();
    }
}
