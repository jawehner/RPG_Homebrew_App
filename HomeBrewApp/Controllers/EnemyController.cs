using HomebrewApp.Models;
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
            var model = new EnemyListItem[0];
            return View(model);
        }
    }
}