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
    [Route("/api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly ItemsService _its;
        public ItemsController(ItemsService its)
        {
            _its = its;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Item>> GetAll()
        {
            try
            {
                return Ok(_its.GetAll());
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Item> GetOne(int id)
        {
            try
            {
                return Ok(_its.GetOne(id));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Item>> Create([FromBody] Item newItem)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                newItem.CreatorId = userInfo.Id;
                Item created = _its.Create(newItem);
                created.Creator = userInfo;
                return Ok(created);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<Item>> Edit(int id, [FromBody] Item editedItem)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                editedItem.Id = id;
                return Ok(_its.Edit(editedItem, userInfo.Id));
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
                return Ok(_its.Delete(id, userInfo.Id));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}