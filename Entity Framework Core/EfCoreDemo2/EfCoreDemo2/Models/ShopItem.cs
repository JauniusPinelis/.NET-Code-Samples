using System;
using System.Collections.Generic;

namespace EfCoreDemo2.Models
{
    public class ShopItem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public Shop Shop { get; set; }

        public int? ShopId { get; set; }
        public List<ShopItemItemTag> ShopItemItemTags { get; set; }
    }
}
