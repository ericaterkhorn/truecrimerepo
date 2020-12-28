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
        // GET: Podcast
        public ActionResult Index()
        {
            var userID = User.Identity.GetUserId();
            var service = new PodcastService(userID);
            var model = service.GetPodcasts();
            return View(model);
        }

        public ActionResult Create()
        {
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

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(PodcastCreate model) 
        //{
        //    var service = CreatePodcastService();

        //     var create = Crime.Select(p => new SelectListItem
        //     {
        //         Text = p.Title,
        //         Value = p.CrimeID.ToString()
        //     });

        //    return View(model);
        //}
        public ActionResult Details(int id)
        {
            var svc = CreatePodcastService();
            var model = svc.GetPodcastByID(id);

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

        private PodcastService CreatePodcastService()
        {
            var userID = User.Identity.GetUserId();
            var service = new PodcastService(userID);
            return service;
        }
    }
}