﻿using HomebrewApp.Models;
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
    public class SettingController : Controller
    {
        // GET: Setting
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SettingService(userId);
            var model = service.GetSettings();

            return View(model);
        }

        public ActionResult Create()
        {
            var service = CreateEnemyService();
            var enemyList = new SelectList(service.GetEnemies(), "EnemyId", "Name");

            //ViewBag.EnemyId = enemyList;
            ViewData["EnemyId"] = enemyList;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SettingCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateSettingService();

            if (service.CreateSetting(model))
            {
                TempData["SaveResult"] = "Setting Created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Setting could not be created.");

            return View(model);
        }

        public ActionResult Details (int id)
        {
            var svc = CreateSettingService();
            var model = svc.GetSettingById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateSettingService();
            var detail = service.GetSettingById(id);
            var enemyService = CreateEnemyService();
            var enemyList = new SelectList(enemyService.GetEnemies(), "EnemyId", "Name", detail.EnemyId);

            //ViewBag.EnemyId = enemyList;
            ViewData["EnemyId"] = enemyList;

            var model =
                new SettingEdit
                {
                    SettingId = detail.SettingId,
                    Name = detail.Name,
                    Type = detail.Type,
                    EnemyId = detail.EnemyId,
                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SettingEdit model)
        {
            var enemyService = CreateEnemyService();
            var enemyList = new SelectList(enemyService.GetEnemies(), "EnemyId", "Name");

            //ViewBag.EnemyId = enemyList;
            ViewData["EnemyId"] = enemyList;

            if (!ModelState.IsValid) return View(model);

            if(model.SettingId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateSettingService();

            if (service.UpdateSetting(model))
            {
                TempData["SaveResult"] = "Setting updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Setting could not be updated.");
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateSettingService();
            var model = svc.GetSettingById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {

            var service = CreateSettingService();

            service.DeleteSetting(id);

            TempData["SaveResult"] = "Setting deleted";


            return RedirectToAction("Index");
        }

        private SettingService CreateSettingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SettingService(userId);
            return service;
        }

        //Call enemyservice?...
        private EnemyService CreateEnemyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EnemyService(userId);
            return service;
        }
    }
}