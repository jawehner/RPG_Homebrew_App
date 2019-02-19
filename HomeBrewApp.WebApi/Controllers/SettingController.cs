using HomebrewApp.Models;
using HomebrewApp.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HomeBrewApp.WebApi.Controllers
{
    [Authorize]
    public class SettingController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            SettingService settingService = CreateSettingService();
            var settings = settingService.GetSettings();
            return Ok(settings);
        }

        public IHttpActionResult Get(int id)
        {
            SettingService settingService = CreateSettingService();
            var setting = settingService.GetSettingById(id);
            return Ok(setting);
        }

        public IHttpActionResult Post(SettingCreate note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSettingService();

            if (!service.CreateSetting(note))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(SettingEdit note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSettingService();

            if (!service.UpdateSetting(note))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateSettingService();

            if (!service.DeleteSetting(id))
                return InternalServerError();

            return Ok();
        }

        private SettingService CreateSettingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var settingService = new SettingService(userId);
            return settingService;
        }
    }
}
