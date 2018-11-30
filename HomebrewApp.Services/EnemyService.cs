using HomebrewApp.Data;
using HomebrewApp.Models;
using HomeBrewApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewApp.Services
{
    public class EnemyService
    {
        private readonly Guid _userId;

        public EnemyService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateEnemy(EnemyCreate model)
        {
            var entity =
                new Enemy()
                {
                    OwnerId = _userId,
                    Name = model.Name,
                    KineticAC = model.KineticAC,
                    EnergyAC = model.EnergyAC,
                    Fortitude = model.Fortitude,
                    Reflex = model.Reflex,
                    Will = model.Will,
                    HP = model.HP,
                    Initiative = model.Initiative,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Enemies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<EnemyListItem> GetEnemies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Enemies
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new EnemyListItem
                                {
                                    EnemyId = e.EnemyId,
                                    Name = e.Name
                                }
                        );

                return query.ToArray();
            }
        }

        public EnemyDetail GetEnemyById(int enemyId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Enemies
                    .Single(e => e.EnemyId == enemyId && e.OwnerId == _userId);
                return
                    new EnemyDetail
                    {
                        EnemyId = entity.EnemyId,
                        Name = entity.Name,
                        KineticAC = entity.KineticAC,
                        EnergyAC = entity.EnergyAC,
                        Fortitude = entity.Fortitude,
                        Reflex = entity.Reflex,
                        Will = entity.Will,
                        HP = entity.HP,
                        Initiative = entity.Initiative
                    };
            }
        }

        public bool UpdateEnemy(EnemyEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Enemies
                    .Single(e => e.EnemyId == model.EnemyId && e.OwnerId == _userId);

                        entity.Name = model.Name;
                        entity.KineticAC = model.KineticAC;
                        entity.EnergyAC = model.EnergyAC;
                        entity.Fortitude = model.Fortitude;
                        entity.Reflex = model.Reflex;
                        entity.Will = model.Will;
                        entity.HP = model.HP;
                        entity.Initiative = model.Initiative;

                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeleteEnemy(int enemyId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Enemies
                        .Single(e => e.EnemyId == enemyId && e.OwnerId == _userId);

                ctx.Enemies.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
