using EfCoreDemo2.Data;
using EfCoreDemo2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EfCoreDemo2.Controllers
{
    public class ShopController : Controller
    {
        private readonly DataContext _context;

        public ShopController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var shops = _context.Shops.ToList();
            return View(shops);
        }

        public IActionResult Edit(int id)
        {
            var shop = _context.Shops.FirstOrDefault(s => s.Id == id);
            return View(shop);
        }

        [HttpPost]
        public IActionResult Edit(Shop shop)
        {
            _context.Shops.Update(shop);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Add()
        {
            var shop = new Shop();
            return View(shop);
        }

        [HttpPost]
        public IActionResult Add(Shop shop)
        {

            _context.Shops.Add(shop);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var shop = _context.Shops.FirstOrDefault(s => s.Id == id);
            _context.Remove(shop);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
