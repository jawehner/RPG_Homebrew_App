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
                TempData["SaveResult"] = "New enemy created.";
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

        public ActionResult Edit(int id)
        {
            var service = CreateEnemyService();
            var detail = service.GetEnemyById(id);
            var model =
                new EnemyEdit
                {
                    EnemyId = detail.EnemyId,
                    Name = detail.Name,
                    KineticAC = detail.KineticAC,
                    EnergyAC = detail.EnergyAC,
                    Fortitude = detail.Fortitude,
                    Reflex = detail.Reflex,
                    Will = detail.Will,
                    HP = detail.HP,
                    Initiative = detail.Initiative,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EnemyEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.EnemyId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateEnemyService();

            if (service.UpdateEnemy(model))
            {
                TempData["SaveResult"] = "Enemy updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Enemy could not be updated.");
            return View();
        }

        [ActionName ("Delete")]
        public ActionResult Delete(int id)
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

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateEnemyService();

            service.DeleteEnemy(id);

            TempData["SaveResult"] = "Enemy deleted.";

            return RedirectToAction("Index");
        }
    }
}