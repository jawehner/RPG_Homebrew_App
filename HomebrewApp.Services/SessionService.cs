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
    public class SessionService
    {
        private readonly Guid _userId;

        public SessionService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateSession(SessionCreate model)
        {
            var entity =
                new Session()
                {
                    OwnerId = _userId,
                    Name = model.Name,
                    Date = model.Date,
                    SettingId = model.SettingId,
                    EnemyId = model.EnemyId,
                    Notes = model.Notes
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Sessions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SessionListItem> GetSessions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = 
                    ctx
                        .Sessions
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new SessionListItem
                                {
                                    SessionId = e.SessionId,
                                    Name = e.Name,
                                    Date = e.Date,
                                    EnemyId = e.EnemyId,
                                    SettingId = e.SettingId,
                                    Notes = e.Notes
                                    //not sure if this is right
                                }
                            
                            );
                return query.ToArray();
            }
        }

        public SessionDetail GetSessionById(int sessionId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Sessions
                        .Single(e => e.SessionId == sessionId && e.OwnerId == _userId);
                return
                new SessionDetail
                {
                    //SessionId = entity.SessionId, -- need this?
                    Name = entity.Name,
                    Date = entity.Date,
                    Setting = entity.Setting,
                    Enemy = entity.Enemy,
                    Notes = entity.Notes
                };
            }
        }

        public bool UpdateSession(SessionEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Sessions
                        .Single(e => e.SessionId == model.SessionId && e.OwnerId == _userId);

                entity.Name = model.Name;
                entity.Date = model.Date;
                entity.SettingId = model.SettingId;
                entity.EnemyId = model.EnemyId;
                entity.Notes = model.Notes;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteSession(int sessionId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Sessions
                    .Single(e => e.SessionId == sessionId && e.OwnerId == _userId);

                ctx.Sessions.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<Enemy> GetEnemies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var sessionEnemy =
                    ctx.Enemies;

                return sessionEnemy.ToArray();
            }
        }

        public IEnumerable<Setting> GetSetting()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var sessionSetting =
                    ctx.Settings;

                return sessionSetting.ToArray();
            }
        }
    }
}
