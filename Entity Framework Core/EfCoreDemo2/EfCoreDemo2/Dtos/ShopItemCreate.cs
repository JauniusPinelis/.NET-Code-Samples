using EfCoreDemo2.Models;
using System.Collections.Generic;
using System.ComponentModel;

namespace EfCoreDemo2.Dtos
{
    public class ShopItemCreate
    {
        public string Name { get; set; }

        public List<Shop> Shops { get; set; }

        [DisplayName("Shop")]
        public int ShopId { get; set; }
    }
}
