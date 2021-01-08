using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrueCrimeRepo.Models;
using TrueCrimeRepo.Services;

namespace TrueCrimeRepo.WebMVC.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        //private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Book
        public ActionResult Index()
        {
            var userID = User.Identity.GetUserId();
            var service = new BookService(userID);
            var model = service.GetBooks();

            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            //var model = new TVShowCreate();
            //model.Crime = _db.Crime.Select(p => new SelectListItem
            //{
            //    Text = p.Title,
            //    Value = p.CrimeID.ToString()
            //});
            //return View(model);

            var crimeServ = CreateCrimeService();
            var getCrimes = crimeServ.GetCrimes();
            ViewBag.Crimes = getCrimes.OrderBy(p => p.Title).ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateBookService();
            if (service.CreateBook(model))
            {
                TempData["SaveResult"] = "Your book was created.";
                return RedirectToAction("Index");  
            }

            ModelState.AddModelError("", "Your book could not be created.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateBookService();
            var model = svc.GetBookByID(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateBookService();
            var detail = service.GetBookByID(id);
            var model =
                new BookEdit
                {
                    BookID = detail.BookID,
                    Title = detail.Title,
                    Description = detail.Description,
                    BookAuthor = detail.BookAuthor
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BookEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.BookID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateBookService();

            if (service.UpdateBook(model))
            {
                TempData["SaveResult"] = "Your true crime book was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your true crime book could not be updated.");
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateBookService();
            var model = svc.GetBookByID(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteBook(int id)
        {
            var service = CreateBookService();

            service.DeleteBook(id);

            TempData["SaveResult"] = "Your true crime book was deleted";

            return RedirectToAction("Index");
        }
        private BookService CreateBookService()
        {
            var userID = User.Identity.GetUserId();
            var service = new BookService(userID);
            return service;
        }

        private CrimeService CreateCrimeService()
        {
            var userID = User.Identity.GetUserId();
            var service = new CrimeService(userID);
            return service;
        }

    }
}