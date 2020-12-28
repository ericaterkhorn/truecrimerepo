using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrueCrimeRepo.Models;

namespace TrueCrimeRepo.WebMVC.Controllers
{
    [Authorize]
    public class TVShowController : Controller
    {
        // GET: TVShow
        public ActionResult Index()
        {
            var model = new TVShowListItem[0];
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
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}