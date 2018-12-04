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

        public bool CreateSession(SessionService model)
        {
            var entity =
                new Session()
                {
                    OwnerId = _userId,
                    Name = model.Name,
                    DateTime = model.DateTime,
                    Enemy = model.Enemy,
                    Session = model.Session,
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
                        .Where (e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new SessionListItem
                                {
                                    SessionId = e.NoteId,
                                    Name = e.Name
                                    //will fill out rest when I know what to do here
                                }
                            
                            );
                return query.ToArray();
            }
        }
    }
}
