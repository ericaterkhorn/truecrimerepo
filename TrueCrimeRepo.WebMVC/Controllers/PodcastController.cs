using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrueCrimeRepo.Models;

namespace TrueCrimeRepo.WebMVC.Controllers
{
    [Authorize]
    public class PodcastController : Controller
    {
        // GET: Podcast
        public ActionResult Index()
        {
            var model = new PodcastListItem[0];
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
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}