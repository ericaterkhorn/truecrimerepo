using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TrueCrimeRepo.Contracts;
using TrueCrimeRepo.Data;
using TrueCrimeRepo.Models;
using TrueCrimeRepo.Services;

namespace TrueCrimeRepo.WebMVC.Controllers
{
    [Authorize]
    public class CrimeController : Controller
    {
        //private ApplicationDbContext _db = new ApplicationDbContext();
        //private readonly ICrimeService _crimeService;

        //public CrimeController(ICrimeService crimeService)
        //{
        //    _crimeService = crimeService;
        //}

        //GET: Crime
        public ActionResult Index()
        {
            var userID = User.Identity.GetUserId();
            var service = new CrimeService(userID);
            var model = service.GetCrimes();

            return View(model);
        }

        //public ActionResult Index(string searchString)
        //{
        //    var userID = User.Identity.GetUserId();
        //    var service = new CrimeService(userID);
        //    var model = service.GetCrimes();
        //    var crimes = from s in _db.Crimes
        //                 select s;

        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        crimes = crimes.Where(s => s.Title.Contains(searchString));
        //    }
        //    return View(_db.Crimes.ToString());
    
        //public ActionResult Index(string Sorting_Order)
        //{
        //    var userID = User.Identity.GetUserId();
        //    var service = new CrimeService(userID);
        //    var model = service.GetCrimes();
        //    ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "Title" : "";
        //    var crimes = from crime in _db.Crimes select crime;
        //    switch (Sorting_Order)
        //    {
        //        case "Title":
        //            crimes = crimes.OrderByDescending(crime => crime.Title);
        //            break;
        //    }
        //    return View(crimes.ToList());
        //}

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CrimeCreate model)
        {
            if (!ModelState.IsValid) return View(model);
           
            var service = CreateCrimeService();
            if (service.CreateCrime(model))
            {
                TempData["SaveResult"] = "Your crime was created.";
                return RedirectToAction("Index");
                
            };
            ModelState.AddModelError("", "Crime could not be created.");
            return View(model);

        }
        public ActionResult Details(int id)
        {
            var svc = CreateCrimeService();
            var model = svc.GetCrimeById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateCrimeService();
            var detail = service.GetCrimeById(id);
            var model =
                new CrimeEdit
                {
                    CrimeID = detail.CrimeID,
                    Title = detail.Title,
                    Description = detail.Description,
                    Perpetrator = detail.Perpetrator,
                    //Perpetrator = detail.Perpetrators,
                    Location = detail.Location,
                    //IsSolved = detail.IsSolved,
                    IsCrimeSolved = detail.IsCrimeSolved,
                    Podcasts = detail.Podcasts,
                    TVShows = detail.TVShows,
                    Books = detail.Books
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CrimeEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CrimeID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateCrimeService();

            if (service.UpdateCrime(model))
            {
                TempData["SaveResult"] = "Your crime was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your crime could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCrimeService();
            var model = svc.GetCrimeById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCrime(int id)
        {
            var service = CreateCrimeService();

            service.DeleteCrime(id);

            TempData["SaveResult"] = "Your crime was deleted";

            return RedirectToAction("Index");
        }

        private CrimeService CreateCrimeService()
        {
            var userID = User.Identity.GetUserId();
            var service = new CrimeService(userID);
            return service;
        }
    }
}