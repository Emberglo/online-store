using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using amazen_server.Models;
using amazen_server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace amazen_server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListsController : ControllerBase
    {
        private readonly ListsService _ls;

        private readonly ListItemsService _lis;

        public ListsController(ListsService ls, ListItemsService lis)
        {
            _ls = ls;
            _lis = lis;
        }

        [HttpGet]
        public ActionResult<IEnumerable<List>> GetAll()
        {
            try
            {
                return Ok(_ls.GetAll());
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("/{listId}/listitems")]
        public ActionResult<IEnumerable<List>> GetItemsByListId(int listId)
        {
            try
            {
                return Ok(_lis.GetItemsByListId(listId));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<List>> Create([FromBody] List newList)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                newList.CreatorId = userInfo.Id;
                List createdList = _ls.Create(newList);
                createdList.Creator = userInfo;
                return Ok(createdList);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<List>> Edit(int id, [FromBody] List editedList)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                editedList.Id = id;
                return Ok(_ls.Edit(editedList, userInfo.Id));
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
                return Ok(_ls.Delete(id, userInfo.Id));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

    }
}