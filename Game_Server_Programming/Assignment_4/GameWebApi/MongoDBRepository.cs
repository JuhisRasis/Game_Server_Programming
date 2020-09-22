using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using System.Linq;


namespace GameWebApi
{
    public class MongoDbRepository : IRepository
    {
        private readonly IMongoCollection<Player> _collection;
        private readonly IMongoCollection<BsonDocument> _bsonDocumentCollection;

        private BsonDocumentSerializer serializer;
        public MongoDbRepository()
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var database = mongoClient.GetDatabase("Game");
            _collection = database.GetCollection<Player>("players");
            _bsonDocumentCollection = database.GetCollection<BsonDocument>("players");
            serializer = new BsonDocumentSerializer();
        }
        public async Task<Player> Create(Player player)
        {
            Player[] playersArray = await ReadFile();
            List<Player> playerlist = playersArray.ToList();
            playerlist.Add(player);
            WriteFile(playerlist.ToArray());
            return player;
        }

        public async Task<Player> Delete(Guid id)
        {
            Player[] players = await ReadFile();
            List<Player> playerlist = players.ToList();
            Player found = players.Where(x => x.Id == id).FirstOrDefault();
            playerlist.Remove(found);
            WriteFile(playerlist.ToArray());
            return found;
        }

        public async Task<Player> Get(Guid id)
        {
            Player[] players = await ReadFile();
            return players.Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task<Player[]> GetAll()
        {
            Player[] temp = await ReadFile();
            return temp;
        }

        public async Task<Player> Modify(Guid id, ModifiedPlayer player)
        {
            Player[] players = await ReadFile();
            players.Where(x => x.Id == id).FirstOrDefault().Score = player.Score;
            WriteFile(players);
            return players.Where(x => x.Id == id).FirstOrDefault();
        }

        async Task<Player[]> ReadFile()
        {
            String jsonString = await System.IO.File.ReadAllTextAsync(Path.GetFullPath("game-dev.txt"));
            if (jsonString.Equals(""))
            {
                return new Player[0];
            }
            Player[] playerlist = JsonConvert.DeserializeObject<Player[]>(jsonString);
            return playerlist;
        }
        void WriteFile(Player[] players)
        {
            System.IO.File.WriteAllText(Path.GetFullPath("game-dev.txt"), JsonConvert.SerializeObject(players));
        }

        public Task<Item> DeleteItem(Guid id, Item item)
        {

            return Task.FromResult<Item>(item);
        }
    }
}