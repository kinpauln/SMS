using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMS.Domain;
using SMS.Domain.Repositories;
using SMS.Entities;
using SMS.UI.Mvc3.Demo.Helpers;
using System.Data;

namespace SMS.UI.Mvc3.Demo.Controllers
{
    public class BooksController : Controller
    {
        //BookDBContext db = new BookDBContext();
        //BookRepository repository = new BookRepository();
        private UnitOfWork unitOfWork = new UnitOfWork();

        private int PAGESIZE = 1;

        public ActionResult Default()
        {
            return View();
        }

        public ActionResult BookList(int? pageIndex)
        {
            IQueryable<Book> books = unitOfWork.BookRepository.Get(orderBy: q => q.OrderBy(d => d.BookId));
            
            var bookList = new PaginatedList<Book>(books, pageIndex ?? 0, PAGESIZE);
            return View("BookList", bookList);
        }

        #region Add

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddOneBook(Book newBook)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Books.Add(newBook);
            //    db.SaveChanges();
            //    return RedirectToAction("BookList");
            //}
            //else
            //    return View(newBook);

            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.BookRepository.Insert(newBook);
                    unitOfWork.Save();
                    return RedirectToAction("BookList");
                }
            }
            catch (DataException)
            { 
                //Log the error (add a variable name after DataException)               
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(newBook);
        }

        #endregion

        #region Detail

        public ActionResult Detail(int bookid)
        {
            Book book = unitOfWork.BookRepository.GetByID(bookid);
            if (book == null)
                return RedirectToAction("BookList");
            else  
                return View("Detail",book);
        }

        #endregion

        #region Edit
        
        public ActionResult Edit(int bookid)
        {
            Book book = unitOfWork.BookRepository.GetByID(bookid);

            if (book == null)
                return RedirectToAction("BookList");
            else
                return View("Edit", book);
        }

        [HttpPost]
        public ActionResult Edit(Book model)
        {
            try
            {
                unitOfWork.BookRepository.Update(model);
                unitOfWork.Save();
                return RedirectToAction("Detail", new { bookid = model.BookId});
            }
            catch (Exception ex) {
                ModelState.AddModelError("", "修改失败，请查看详细错误信息。");
            }
            return View(model);
        }

        #endregion

        #region Delete

        public ActionResult Delete(int bookid) {

            Book book = unitOfWork.BookRepository.GetByID(bookid);
            if (book == null)
                return RedirectToAction("BookList");
            else
                return View(book);
        }

        [HttpPost]
        public ActionResult Delete(int bookid,FormCollection collection)
        {
            unitOfWork.BookRepository.Delete(bookid);
            unitOfWork.Save();
            this.HttpContext.Request.Headers.Add("", "");
            return RedirectToAction("BookList");
        }

        public ActionResult DeleteExec(int bookid)
        {
            unitOfWork.BookRepository.Delete(bookid);
            unitOfWork.Save();
            return RedirectToAction("BookList");
        }

        #endregion
    }
}
