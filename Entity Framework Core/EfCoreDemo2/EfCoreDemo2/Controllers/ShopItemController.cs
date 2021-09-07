using EfCoreDemo2.Data;
using EfCoreDemo2.Dtos;
using EfCoreDemo2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EfCoreDemo2.Controllers
{
    public class ShopItemController : Controller
    {
        private readonly DataContext _context;

        public ShopItemController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var items = _context.ShopItems
                .Include(s => s.Shop).ToList();

            var allShops = _context.Shops.ToList();

            var dto = new ShopItemIndex()
            {
                ShopItems = items,
                Shops = allShops
            };

            return View(dto);
        }

        [HttpPost]
        public IActionResult Index(ShopItemIndex model)
        {
            var items = _context.ShopItems
                .Include(s => s.Shop).ToList();

            var allShops = _context.Shops.ToList();

            var dto = new ShopItemIndex()
            {
                ShopItems = items.Where(i => i.ShopId == model.ShopId || model.ShopId == 0).ToList(),
                Shops = allShops
            };

            return View(dto);
        }

        public IActionResult Add()
        {
            var shopItem = new ShopItemCreate();
            shopItem.Shops = _context.Shops.ToList();
            return View(shopItem);
        }

        [HttpPost]
        public IActionResult Add(ShopItemCreate shopItemCreate)
        {
            var mappedEntity = new ShopItem()
            {
                Name = shopItemCreate.Name,
                ShopId = shopItemCreate.ShopId
            }; //mapping

            _context.ShopItems.Add(mappedEntity);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
