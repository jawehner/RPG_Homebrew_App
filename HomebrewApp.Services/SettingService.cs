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

        public SettingDetail GetSettingById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Settings
                    .Single(e => e.SettingId == settingId && e.OwnerId == _userId);
                return
                    new SettingDetail
                    {
                        SettingId = entity.SettingId,
                        Name = entity.Name,
                        Type = entity.Type,
                        //Enemy = entity.Enemy -- What do?!?!
                    };
            }
        }

        public bool UpdateSetting(SettingEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Settings
                        .Sinle(e = e.SettingId == model.SettingId && e.OwnerId == _userId);

                entity.Name = model.Name;
                entity.Type = model.Type;
                // entity.Enemy = model.Enemy;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteSetting(int settingId)
        {

            using (var ctx = new ApplicationDbContext())
            {

                var entity =
                    ctx
                        .Settings
                        .Single(e => e.SettingId == settingId && e.OwnerId == _userId);
                ctx.Settings.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
