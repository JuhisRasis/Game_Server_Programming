using System;
using System.Threading.Tasks;

namespace GameWebApi
{
    public interface IRepository
    {

        Task<Player> Get(Guid id);
        Task<Player[]> GetAll();
        Task<Player> Create(Player player);
        Task<Player> Modify(Guid id, ModifiedPlayer player);
        Task<Player> Delete(Guid id);

        //Task<Player> CreatePlayer(Player player);
        //Task<Player> GetPlayer(Guid playerId);
        //Task<Player[]> GetAllPlayers();
        //Task<Player> UpdatePlayer(Player player);
        //Task<Player> DeletePlayer(Guid playerId;

        //Task<Item> CreateItem(Guid playerId, Item item);
        //Task<Item> GetItem(Guid playerId, Guid itemId);
        //Task<Item[]> GetAllItems(Guid playerId);
        //Task<Item> UpdateItem(Guid playerId, Item item);
        //Task<Item> DeleteItem(Guid playerId, Item item);

    }
}