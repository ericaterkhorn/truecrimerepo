using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrueCrimeRepo.Models;

namespace TrueCrimeRepo.WebMVC.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        //private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Book
        public ActionResult Index()
        {
            var model = new BookListItem[0];
            return View();
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

            //var crimeServ = CreateCrimeService();
            //var getCrimes = crimeServ.GetCrimes();
            //ViewBag.Crimes = getCrimes.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }

        //private CrimeService CreateCrimeService()
        //{
        //    var userID = User.Identity.GetUserId();
        //    var service = new CrimeService(userID);
        //    return service;
        //}
    }
}