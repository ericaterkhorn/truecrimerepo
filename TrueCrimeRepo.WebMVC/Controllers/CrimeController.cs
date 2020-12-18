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
    public class CrimeController : Controller
    {
        // GET: Crime
        public ActionResult Index()
        {
            //var model = new CrimeListItem[0];
            //var userId = Guid.Parse(User.Identity.GetUserId());
            var userID = User.Identity.GetUserId();
            var service = new CrimeService(userID);
            var model = service.GetCrimes();
            return View(model);
        }

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
                    Location = detail.Location,
                    IsSolved = detail.IsSolved
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

        private CrimeService CreateCrimeService()
        {
            var userID = User.Identity.GetUserId();
            var service = new CrimeService(userID);
            return service;
        }
    }
}