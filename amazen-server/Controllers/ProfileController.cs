using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using amazen_server.Models;
using amazen_server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace amazen_server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly ProfilesService _ps;

        private readonly ItemsService _its;

        public ProfileController(ProfilesService ps, ItemsService its)
        {
            _ps = ps;
            _its = its;
        }

        [HttpGet]
        [Authorize]

        public async Task<ActionResult<ProfileController>> Get()
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                return Ok(_ps.GetOrCreateProfile(userInfo));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{id}/items")]
        public async Task<ActionResult<Profile>> GetItemsByProfile(string id)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                return Ok(_its.GetItemsByProfile(id, userInfo?.Id));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        // [HttpGet("{id}/lists")]
        // public async Task<ActionResult<Profile>> GetListsByProfile(string id)
        // {
        //     try
        //     {
        //         Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        //         return Ok(_is.GetItemsByProfile(id, userInfo?.Id));
        //     }
        //     catch (Exception err)
        //     {
        //         return BadRequest(err.Message);
        //     }
        // }
    }
}