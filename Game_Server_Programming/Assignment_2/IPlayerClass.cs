using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace Assignment_2
{
    public class Player : IPlayer
    {
        public Guid Id { get; set; }
        public int Score { get; set; }
        public List<Item> Items { get; set; }



        public Player(Guid id)
        {
            Id = id;
            Items = new List<Item>();
        }

    }

    public static class GetHighestLevelItemExtension
    {
        public static Item GetHighestLevelItem(this Player player)
        {
            return player.Items.OrderByDescending(i => i.Level).First();

        }
    }

    public static class GetItemsClass
    {
        public static Item[] GetItem(Player player)
        {
            Item[] items = new Item[player.Items.Count];
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = player.Items[i];

            }
            return items;
        }

        public static Item[] GetItemsUsingLINQ(Player player)
        {
            return player.Items.ToArray();
        }

        public static Item GetFirstItem(Player player)
        {

            return player.Items[0];

        }

        public static Item FirstItemWithLinq(Player player)
        {

            return player.Items.First(); ;

        }

        delegate int Transformer(int x);

        public static void ProcessEachItem(Player player, Action<Item> process)
        {

        }

        public static void ProcessEachItemDelegate(Item item)
        {

        }
    }
}
