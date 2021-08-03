using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MsSqlExample.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MsSqlExample.Controllers
{
    public class HomeController : Controller
    {
        private SqlConnection _connection;

        public HomeController(SqlConnection connection)
        {
            _connection = connection;
        }

        public IActionResult Index()
        {
            List<ItemModel> items = new();

            _connection.Open();

            using var command = new SqlCommand("SELECT Id, Name FROM dbo.Items;", _connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                items.Add(new ItemModel()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1)
                });
            }

            _connection.Close();

            return View(items);
        }

        public IActionResult DisplayAddNewItem()
        {
            return View("AddNewItem");
        }

        public IActionResult AddNewItem(ItemModel model)
        {
            _connection.Open();

            string insertText = $"insert into dbo.Items (Name) values('{model.Name}'); ";

            SqlCommand command = new SqlCommand(insertText, _connection);
            command.ExecuteNonQuery();

            _connection.Close();

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
