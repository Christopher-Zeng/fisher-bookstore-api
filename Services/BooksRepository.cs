using System.Collections.Generic;
using Fisher.Bookstore.Data;
using Fisher.Bookstore.Models;

namespace Fisher.Bookstore.Services
{

    public class BooksRepository : IBooksRepository
    {
        private readonly BookstoreContext db;

        public BooksRepository(BookstoreContext db) => this.db = db;

        public int AddBook(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
            return book.Id;
        }

        public bool BookExists(int bookId)
        {
            return (db.Books.Find(bookId) != null);
        }

        public void DeleteBook(int bookId)
        {
            db.Books.Remove(db.Books.Find(bookId));
            db.SaveChanges();
        }

        public Book GetBook(int bookId)
        {
            return db.Books.Find(bookId);
        }

        public IEnumerable<Book> GetBooks()
        {
            return db.Books;
        }

        public void UpdateBook(Book book)
        {
            db.Books.Update(book);
            db.SaveChanges();
        }
    }
}