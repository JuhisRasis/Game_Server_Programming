using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GameWebApi
{
    public interface IRepository
    {

        //Task<Player> Get(Guid id);
        Task<Player[]> GetAll();
        Task<Player> Create(Player player);
        Task<Player> Modify(Guid id, ModifiedPlayer player);
        Task<Player> Delete(Guid id);

    }

    [Serializable]
    public class PlayerData
    {
        public List<Player> Players { get; set; }

        public PlayerData()
        {
            if (Players == null)
            {
                Players = new List<Player>();
            }
        }
    }
    public class FileRepository : IRepository
    {



        PlayerData _playerData;
        private string _fileName = "game-dev.txt";
        private string _filePath = Environment.CurrentDirectory;
        public FileRepository()
        {
            Console.WriteLine("LoadFile");
            LoadFile();
        }

        public void LoadFile()
        {
            try
            {
                if (File.Exists(Path.Combine(_filePath, _fileName)))
                {
                    string jsonString = File.ReadAllText(Path.Combine(_filePath, _fileName));
                    _playerData = JsonConvert.DeserializeObject<PlayerData>(jsonString);
                }
                else
                {
                    _playerData = new PlayerData();
                    _playerData.Players = new List<Player>();
                    for (int i = 0; i < 10; i++)
                    {
                        Player p = new Player()
                        {
                            Id = Guid.NewGuid(),
                            Name = "Random nimi...." + i,
                            CreationTime = DateTime.UtcNow
                        };
                        _playerData.Players.Add(p);

                    }
                }
            }
            catch (IOException ioe)
            {
                Console.WriteLine("Unable to load file " + ioe);
            }
            catch (JsonException jse)
            {
                Console.WriteLine("Unable to deserialize..." + jse);
            }
        }

        public Task<Player> Create(Player player)
        {
            _playerData.Players.Add(player);

            return Task.FromResult<Player>(player);
        }

        public Task<Player> Delete(Guid id)
        {
            Player p = _playerData.Players.Find(item => item.Id == id);

            _playerData.Players.Remove(p);
            return Task.FromResult<Player>(p);
        }

        public Task<Player[]> GetAll()
        {
            return Task.FromResult<Player[]>(_playerData.Players.ToArray());
        }

        public Task<Player> Get(Guid id)
        {
            Player playerId = _playerData.Players.Find(item => item.Id == id);
            return Task.FromResult<Player>(playerId);

        }

        public Task<Player> Modify(Guid id, ModifiedPlayer player)
        {
            Player p = _playerData.Players.Find(item => item.Id == id);
            p.Score = player.Score;
            return Get(p.Id);
        }
    }
}