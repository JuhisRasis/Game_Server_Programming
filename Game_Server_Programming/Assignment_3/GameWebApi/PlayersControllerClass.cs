using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GameWebApi
{

    class PlayersControllerClass : FileRepository
    {

        private FileRepository _IRepo;
        public PlayersControllerClass(FileRepository repo)
        {
            _IRepo = repo;
        }

        [HttpGet("/api/players/{id}")]
        public async Task<Player> GetPlayer(string id)
        {
            Guid g = Guid.Parse(id);
            return await _IRepo.Get(g);
        }
        [HttpGet("/api/players/all")]
        public new async Task<Player[]> GetAll()
        {
            return await _IRepo.GetAll();
        }
        [HttpPost("/api/players/Create")]

        public async Task<Player> Create(NewPlayer newPlayer)
        {
            var player = new Player()
            {
                Id = Guid.NewGuid(),
                Name = newPlayer.Name,
                CreationTime = DateTime.UtcNow
            };


            return await _IRepo.Create(player);
        }

        [HttpPut("/api/players/modify/{playerId}")]
        public new async Task<Player> Modify(Guid playerId, ModifiedPlayer player)
        {
            return await _IRepo.Modify(playerId, player);
        }
        [HttpDelete("/api/players/delete/{playerId}")]
        public async Task<Player> Delete(string playerId)
        {
            Guid g = Guid.Parse(playerId);

            return await _IRepo.Delete(g);
        }
    }
}