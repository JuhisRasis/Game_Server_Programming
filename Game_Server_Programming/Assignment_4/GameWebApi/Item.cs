using System;

namespace GameWebApi
{
    using GameWebApi.Validation;
    public class Item
    {

        public Guid Id { get; set; }
        public int Price { get; set; }

        [Type]
        public ItemType ItemType { get; set; }

        [Level]
        public int Level { get; set; }

        [PastDate]
        DateTime CreationTime { get; set; }
    }

}