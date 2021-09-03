using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreDemo2.Models
{
    public class ShopItemItemTag
    {
        public int ShopItemId { get; set; }

        public ShopItem ShopItem { get; set; }

        public ItemTag Tag { get; set; }
        public int TagId { get; set; }
    }
}
