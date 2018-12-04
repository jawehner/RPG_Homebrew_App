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
    public class SettingService
    {
        private readonly Guid _userId;

        public SettingService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateSetting(SettingCreate model)
        {
            var entity =
                new Setting()
                {
                    OwnerId = _userId,
                    Name = model.Name,
                    Type = model.Type
                    //Enemy = model.Enemy
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Settings.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SettingListItem> GetSettings()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Settings
                    .Where(e=> e.OwnderId == _userId)
                    .Select(
                        e =>
                        new SettingListItem
                        {
                            SettingId = e.SettingId,
                            Name = e.Name,
                            Type = e.Type,
                            //Enemy?
                        }

                     );
                return query.ToArray();
            }
        }
    }
}
