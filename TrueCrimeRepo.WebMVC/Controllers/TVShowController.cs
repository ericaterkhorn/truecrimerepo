﻿using Microsoft.AspNet.Identity;
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
    public class TVShowController : Controller
    {
        //private ApplicationDbContext _db = new ApplicationDbContext();
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

        public ActionResult Details(int id)
        {
            var svc = CreateTVShowService();
            var model = svc.GetTVShowByID(id);

            return View(model);
        }

        private TVShowService CreateTVShowService()
        {
            var userID = User.Identity.GetUserId();
            var service = new TVShowService(userID);
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