using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrueCrimeRepo.Data;
using TrueCrimeRepo.Models;
using TrueCrimeRepo.Services;

namespace TrueCrimeRepo.WebMVC.Controllers
{
    [Authorize]
    public class PodcastController : Controller
    {
        //private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Podcast
        public ActionResult Index()
        {
            var userID = User.Identity.GetUserId();
            var service = new PodcastService(userID);
            var model = service.GetPodcasts();
            return View(model);
        }

        //public ActionResult Create()
        //{
        //    return View();
        //}

        public ActionResult Create()
        {
            //var model = new PodcastCreate();
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
        public ActionResult Create(PodcastCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreatePodcastService();

            if (service.CreatePodcast(model))
            {
                TempData["SaveResult"] = "Your podcast was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Podcast could not be created.");
            
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreatePodcastService();
            var model = svc.GetPodcastByID(id);

            //var crimeServ = CreateCrimeService();
            //var getCrimes = crimeServ.GetCrimes();
            //ViewBag.Crimes = getCrimes.ToList();

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreatePodcastService();
            var detail = service.GetPodcastByID(id);
            var model =
                new PodcastEdit
                {
                    PodcastID = detail.PodcastID,
                    Title = detail.Title,
                    PodcastEpisodeTitle = detail.PodcastEpisodeTitle,
                    Description = detail.Description,
                    WebsiteUrl = detail.WebsiteUrl
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PodcastEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PodcastID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreatePodcastService();

            if (service.UpdatePodcast(model))
            {
                TempData["SaveResult"] = "Your podcast was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your podcast could not be updated.");
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var svc = CreatePodcastService();
            var model = svc.GetPodcastByID(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePodcast(int id)
        {
            var service = CreatePodcastService();

            service.DeletePodcast(id);

            TempData["SaveResult"] = "Your Podcast was deleted.";

            return RedirectToAction("Index");
        }
        
        private CrimeService CreateCrimeService()
        {
            var userID = User.Identity.GetUserId();
            var service = new CrimeService(userID);
            return service;
        }
        private PodcastService CreatePodcastService()
        {
            var userID = User.Identity.GetUserId();
            var service = new PodcastService(userID);
            return service;
        }

    }
}