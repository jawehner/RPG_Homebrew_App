using HomebrewApp.Models;
using HomebrewApp.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Http;

namespace HomeBrewApp.WebApi.Controllers
{
    [Authorize]
    public class EnemyController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            EnemyService enemyService = CreateEnemyService();
            var enemies = enemyService.GetEnemies();
            return Ok(enemies);
        }

        public IHttpActionResult Get(int id)
        {
            EnemyService enemyService = CreateEnemyService();
            var enemy = enemyService.GetEnemyById(id);
            return Ok(enemy);
        }

        public IHttpActionResult Post(EnemyCreate note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateEnemyService();

            if (!service.CreateEnemy(note))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(EnemyEdit note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateEnemyService();

            if (!service.UpdateEnemy(note))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateEnemyService();

            if (!service.DeleteEnemy(id))
                return InternalServerError();

            return Ok();
        }

        private EnemyService CreateEnemyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var enemyService = new EnemyService(userId);
            return enemyService;
        }
    }
}
