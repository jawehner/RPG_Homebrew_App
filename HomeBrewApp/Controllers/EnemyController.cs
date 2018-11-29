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
    public class EnemyController : Controller
    {
        // GET: Enemy
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EnemyService(userId);
            var model = service.GetEnemies();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EnemyCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateEnemyService();

            if (service.CreateEnemy(model))
            {
                TempData["SaveResult"] = "New Enemy Created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Enemy could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateEnemyService();
            var model = svc.GetEnemyById(id);

            return View(model);
        }

        private EnemyService CreateEnemyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EnemyService(userId);
            return service;
        }
    }
}