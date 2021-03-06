using System.Collections.Generic;
using Fisher.Bookstore.Data;
using Fisher.Bookstore.Models;

namespace Fisher.Bookstore.Services
{
    
    public class AuthorsRepository : IAuthorsRepository
    {

        private readonly BookstoreContext db;

        public AuthorsRepository(BookstoreContext db) => this.db = db;

        public IEnumerable<Author> GetAuthors() => db.Authors;
        public Author GetAuthor(int authorId) => db.Authors.Find(authorId);
        public int AddAuthor(Author author)
        {
            db.Authors.Add(author);
            db.SaveChanges();
            return author.Id;
        }
        public void UpdateAuthor(Author author)
        {
            db.Authors.Update(author);
            db.SaveChanges();
        } 
        public void DeleteAuthor(int authorId)
        {
            db.Authors.Remove(db.Authors.Find(authorId));
            db.SaveChanges();
        }
        public bool AuthorExists(int authorId) => (db.Authors.Find(authorId) != null);
    }
}