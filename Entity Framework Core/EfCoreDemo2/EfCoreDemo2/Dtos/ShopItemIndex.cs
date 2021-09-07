using EfCoreDemo2.Models;
using System.Collections.Generic;
using System.ComponentModel;

namespace EfCoreDemo2.Dtos
{
    public class ShopItemIndex
    {
        [DisplayName("Shop")]
        public int ShopId { get; set; }

        public List<ShopItem> ShopItems { get; set; }

        public List<Shop> Shops
        {
            get; set;
        }
    }
}
