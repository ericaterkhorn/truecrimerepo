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
    public class TVShowController : Controller
    {
        // GET: TVShow
        public ActionResult Index()
        {
            var userID = User.Identity.GetUserId();
            var service = new TVShowService(userID);
            var model = service.GetTVShows();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TVShowCreate model)
        {
            if (!ModelState.IsValid) return View(model);
           
            var service = CreateTVShowService();
            if (service.CreateTVShow(model))
            {
                TempData["SaveResult"] = "Your TV Show or Documentary was created.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your TV Show or Documentary could not be created.");

            return View(model);
        }

        

        private TVShowService CreateTVShowService()
        {
            var userID = User.Identity.GetUserId();
            var service = new TVShowService(userID);
            return service;
        }
    }
}