using EfCoreDemo2.Models;
using System.Collections.Generic;

namespace EfCoreDemo2.Dtos
{
    public class ShopItemCreate
    {
        public string Name { get; set; }

        public List<Shop> Shops { get; set; }

        public int ShopId { get; set; }
    }
}
