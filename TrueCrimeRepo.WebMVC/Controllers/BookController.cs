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
            ViewBag.Crimes = getCrimes.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookCreate model)
        {
            if (ModelState.IsValid) return View(model);

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