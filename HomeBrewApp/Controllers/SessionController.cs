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
            var model = service.GetSessions();

            return View(model);
        }

        public ActionResult Create()
        {
            var enemyService = CreateEnemyService();
            var enemyList = new SelectList(enemyService.GetEnemies(), "EnemyId", "Name");

            ViewData["EnemyId"] = enemyList;

            var settingService = CreateSettingService();
            var settingList = new SelectList(settingService.GetSettings(), "SettingId", "Name");

            ViewData["SettingId"] = settingList;

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

        public ActionResult Details(int id)
        {
            var svc = CreateSessionService();
            var model = svc.GetSessionById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateSessionService();
            var detail = service.GetSessionById(id);
            var model =
                new SessionEdit
                {
                    SessionId = detail.SessionId,
                    Name = detail.Name,
                    Date = detail.Date,
                    SettingId = detail.SettingId,
                    EnemyId = detail.EnemyId,
                    Notes = detail.Notes
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SessionEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.SessionId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }


            var service = CreateSessionService();

            if (service.UpdateSession(model))
            {
                TempData["SaveResult"] = "Session Updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Session could not be created.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateSessionService();
            var model = svc.GetSessionById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSession(int id)
        {
            var service = CreateSessionService();

            service.DeleteSession(id);

            TempData["SaveResult"] = "Session Deleted";

            return RedirectToAction("Index");
        }

        private SessionService CreateSessionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SessionService(userId);
            return service;
        }

        private EnemyService CreateEnemyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EnemyService(userId);
            return service;
        }

        private SettingService CreateSettingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SettingService(userId);
            return service;
        }
    }
}