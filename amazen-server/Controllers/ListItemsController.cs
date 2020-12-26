using System;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using amazen_server.Models;
using amazen_server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace amazen_server.Controllers
{
    [ApiController]
    [Route("api/[controller")]
    public class ListItemsController : ControllerBase
    {
        private readonly ListItemsService _lis;

        public ListItemsController(ListItemsService lis)
        {
            _lis = lis;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ListItem>> Post([FromBody] ListItem newListItem)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                newListItem.CreatorId = userInfo.Id;
                return Ok(_lis.Create(newListItem));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<string>> Delete(int id)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                return Ok(_lis.Delete(id, userInfo.Id));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

    }
}