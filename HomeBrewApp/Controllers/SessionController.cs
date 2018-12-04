using HomebrewApp.Models;
using HomebrewApp.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeBrewApp.Controllers
{
    [Authorize]
    public class SessionController : Controller
    {
        // GET: Session
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SessionService(userId);
            var model = new SessionListItem[0];

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SessionCreate model)
        {
            if (!ModelState.IsValid) return View(model);
           
            var service = CreateSessionService();

            if (service.CreateSession(model))
            {
                TempData["SaveResult"] = "Session created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Session could not be created.");

            return View(model);
        }

        private SessionService CreateSessionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SessionService(userId);
            return service;
        }
    }
}