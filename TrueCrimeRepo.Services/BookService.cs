﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueCrimeRepo.Data;
using TrueCrimeRepo.Models;

namespace TrueCrimeRepo.Services
{
    class BookService
    {
        private readonly string _userID;
        private ApplicationUser _user;

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
                    //CreatedUtc = DateTimeOffset.Now
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
                        .Where(e => e.UserId == _userID)
                        .Select(
                            e =>
                                new BookListItem
                                {
                                    BookID = e.BookID,
                                    CrimeID = e.CrimeID,
                                    Title = e.Title,
                                    Description = e.Description,
                                    BookAuthor = e.BookAuthor
                                }
                        );

                return query.ToArray();
            }
        }

    }
}
