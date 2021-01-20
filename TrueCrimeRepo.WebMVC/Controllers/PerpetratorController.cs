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

            //var userID = User.Identity.GetUserId();
            //var service = new PerpetratorService(userID);
            //var model = service.GetPerpetrators();

            //return View(model);
        }


        //GET
        public ActionResult Create()
        {
            //var crimeServ = CreateCrimeService();
            //var getCrimes = crimeServ.GetCrimes();
            //ViewBag.Crimes = getCrimes.OrderBy(p => p.Title).ToList();
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

        public ActionResult Details(int id)
        {
            var svc = CreatePerpetratorService();
            var model = svc.GetPerpetratorByID(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreatePerpetratorService();
            var detail = service.GetPerpetratorByID(id);
            var model =
                new PerpetratorEdit
                {
                    PerpetratorID = detail.PerpetratorID,
                    Name = detail.Name,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PerpetratorEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PerpetratorID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreatePerpetratorService();

            if (service.UpdatePerpetrator(model))
            {
                TempData["SaveResult"] = "Your perpetrator was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your perpetrator could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreatePerpetratorService();
            var model = svc.GetPerpetratorByID(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePerpetrator(int id)
        {
            var service = CreatePerpetratorService();

            service.DeletePerpetrator(id);

            TempData["SaveResult"] = "Your perpetrator was deleted";

            return RedirectToAction("Index");
        }
        private PerpetratorService CreatePerpetratorService()
        {
            var userID = User.Identity.GetUserId();
            var service = new PerpetratorService(userID);
            return service;
        }
        //private CrimeService CreateCrimeService()
        //{
        //    var userID = User.Identity.GetUserId();
        //    var service = new CrimeService(userID);
        //    return service;
        //}
    }
}