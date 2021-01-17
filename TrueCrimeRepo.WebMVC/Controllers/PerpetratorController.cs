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
    public class PerpetratorController : Controller
    {
        // GET: Perpetrator
        public ActionResult Index()
        {
            PerpetratorService service = CreatePerpetratorService();
            var model = service.GetPerpetrators();

            return View(model);
        }


        //GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PerpetratorCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreatePerpetratorService();

            if (service.CreatePerpetrator(model))
            {
                TempData["SaveResult"] = "Your perpetrator was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Perpetrator could not be created.");


            return View(model);
        }
        private PerpetratorService CreatePerpetratorService()
        {
            var userID = User.Identity.GetUserId();
            var service = new PerpetratorService(userID);
            return service;
        }
    }
}