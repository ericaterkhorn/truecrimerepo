using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueCrimeRepo.Data;
using TrueCrimeRepo.Models;

namespace TrueCrimeRepo.Services
{
    public class BookService
    {
        private readonly string _userID;
        //private ApplicationUser _user;

        public BookService(string userID)
        {
            _userID = userID;
        }

        public bool CreateBook(BookCreate model)
        {
            var entity =
                new Book()
                {
                    UserId = _userID,
                    CrimeID = model.CrimeID,
                    Crime = model.Crime,
                    Title = model.Title,
                    Description = model.Description,
                    BookAuthor = model.BookAuthor,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Books.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<BookListItem> GetBooks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Books
                        //.Where(e => e.UserId == _userID)
                        .Select(
                            e =>
                                new BookListItem
                                {
                                    BookID = e.BookID,
                                    CrimeID = e.CrimeID,
                                    Crime = e.Crime,
                                    Title = e.Title,
                                    Description = e.Description,
                                    BookAuthor = e.BookAuthor
                                }
                        );

                return query.ToArray();
            }
        }

        public BookDetail GetBookByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Books
                        .Single(e => e.BookID == id); /*&& e.UserId == _userID);*/
                return
                    new BookDetail
                    {
                        BookID = entity.BookID,
                        CrimeID = entity.CrimeID,
                        Crime = entity.Crime,
                        Title = entity.Title,
                        Description = entity.Description,
                        BookAuthor = entity.BookAuthor,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
        public bool UpdateBook(BookEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Books
                        .Single(e => e.BookID == model.BookID); /*&& e.UserId == _userID);*/

                entity.Title = model.Title;
                entity.Description = model.Description;
                entity.BookAuthor = model.BookAuthor;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteBook(int bookID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Books
                        .Single(e => e.BookID == bookID); /*&& e.UserId == _userID);*/

                ctx.Books.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
