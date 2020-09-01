using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_1
{

    public class BikeRentalStationList {
        public List<Stations> stations;
        public class Stations {
            public int id {get; set;}
            public string name {get; set;}
            public int bikesAvailable {get; set;}
        }
    }

    class Program
    {
        public static async Task Main(string[] args)
        {
            ICityBikeDataFetcher fetcher;
            fetcher = new RealTimeCityBikeDataFetcher();
            var task = fetcher.GetBikeCountInStation("Petikontie");
            await task;
        }
    }

    public interface ICityBikeDataFetcher{
    Task<int> GetBikeCountInStation(string stationName);
}


    public class NotFoundException : Exception 
{
    public NotFoundException() {
    }
}



    public class RealTimeCityBikeDataFetcher : ICityBikeDataFetcher
    {
        HttpClient client = new HttpClient() {
            BaseAddress = new Uri(@"http://api.digitransit.fi/routing/v1/routers/hsl/bike_rental")
        };

    
        public async Task<int> GetBikeCountInStation(string stationName)
        {
            BikeRentalStationList lista;
            
            Console.WriteLine(stationName.Any(c => char.IsDigit(c)));
            try {
                if(stationName.Any(c => char.IsDigit(c))) {
                    throw new ArgumentException();
                }
            } catch (ArgumentException ae) {
                Console.WriteLine("Invalid argument: " + ae);
                return -1;
            } finally {
                lista = JsonConvert.DeserializeObject<BikeRentalStationList>(await client.GetStringAsync(client.BaseAddress));


            }
            try {
                if(!lista.stations.Exists(item => item.name == stationName)) {
                    throw new NotFoundException();
                }
            }  catch (NotFoundException nfe) {
                Console.WriteLine("Not found: " + nfe);
                return -1;  
            }
            Console.WriteLine(lista.stations.Find(item => item.name == stationName).bikesAvailable);
            return lista.stations.Find(item => item.name == stationName).bikesAvailable;
        }
    }
}