using System;
using System.Linq;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        delegate int Transformer(int x);

        static void Main(string[] args)
        {


            IList<Guid> guidArrayList = new List<Guid>();
            IList<Player> playerArrayList = new List<Player>();
            IList<Item> itemsList = new List<Item>();

            List<string> pList = new List<string>();
            Guid guid = Guid.NewGuid();

            Item item1 = new Item();
            item1.Id = guid;
            item1.Level = 5;
            guid = Guid.NewGuid();
            itemsList.Add(item1);

            Item item2 = new Item();
            item2.Id = guid;
            item2.Level = 10;
            itemsList.Add(item2);

            Item item3 = new Item();
            item3.Id = guid;
            item3.Level = 15;
            itemsList.Add(item3);

            for (int i = 0; i < 1000; i++)
            {
                guid = Guid.NewGuid();
                Guid[] guids = guid.DuplicateGuids();
                //guidArrayList.Add(guid);


                Player player = new Player(guid);
                playerArrayList.Add(player);
                playerArrayList[i].Id = guid;


                Random rnd = new Random();
                int itemSelected = rnd.Next(1, 3);

                Console.WriteLine(playerArrayList[i].Id + "   i" + i);
                switch (itemSelected)
                {
                    case 1:
                        Console.WriteLine((itemsList[0].Id));
                        Console.WriteLine((itemsList[0].Level));
                        Console.WriteLine(playerArrayList[i].Id + "\n\n");
                        playerArrayList[i].Items.Add(itemsList[0]);
                        break;

                    case 2:
                        Console.WriteLine((itemsList[1].Id));
                        Console.WriteLine((itemsList[1].Level));
                        Console.WriteLine(playerArrayList[i].Id + "\n\n");
                        playerArrayList[i].Items.Add(itemsList[1]);
                        break;

                    case 3:
                        Console.WriteLine((itemsList[2].Id));
                        Console.WriteLine((itemsList[2].Level));
                        Console.WriteLine(playerArrayList[i].Id + "\n\n");
                        playerArrayList[i].Items.Add(itemsList[2]);

                        break;

                }

            }
            Console.WriteLine("player0 Item with the highest level: " + playerArrayList[0].GetHighestLevelItem().Level);

            if (playerArrayList.Count != playerArrayList.Distinct().Count())
            {
                Console.WriteLine("Duplicate found!");

            }
            else
            {
                Console.WriteLine("No duplicates found!");
            }

        }

        //ProcessEachItem(player, PrintItem(Item))

        private static void PrintItem(Item item)
        {
            Console.WriteLine("Id:" + item.Id + ", Level:" + item.Level);
        }

    }




    [CustomAttribute("Test", 3, Example = "Example")]
    public static class GuidExtensions
    {
        public static Guid[] DuplicateGuids(this Guid guid)
        {
            return new Guid[] { guid, guid };
        }
    }


    public class CustomAttribute : Attribute
    {
        public string Example { get; set; }
        public CustomAttribute(string name, int number)
        {

        }
    }



}
