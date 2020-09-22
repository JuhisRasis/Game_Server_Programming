using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GameWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ItemController : ControllerBase
    {
        private readonly ILogger<PlayersController> _logger;
        private readonly IRepository _repo;
        public ItemController(ILogger<PlayersController> logger, IRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }
        /*
        [HttpGet("/players/{playerId}/items/{itemId}")]
        public async Task<Item> GetItem(Guid playerId, Guid itemId)
        {
            return await _repo.GetItem(playerId, itemId);
        }

        [HttpGet("/players/{playerId}/items/all")]
        public async Task<Item[]> GetAllItems(Guid playerId)
        {
            return await _repo.GetAllItems(playerId);
        }

                [HttpPost("/players/{playerId}/items/create")]
                public async Task<Item> CreateItem(Guid playerId, NewItem newItem)
                {

                    return await _repo.CreateItem(playerId, newItem);
                }

                [HttpPut("/players/{playerId}/items/modify/{index}/")]
                public async Task<Item> UpdateItem(Guid playerId, int index, ModifiedItem player)
                {
                    return await _repo.UpdateItem(playerId, index, player);
                }

        [HttpDelete("/players/{playerId}/items/delete/")]
        public async Task<Item> DeleteItem(Guid playerId, Item item)
        {
            return await _repo.DeleteItem(playerId, item);
        }
         */
    }
}