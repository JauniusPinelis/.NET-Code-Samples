using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySqlConnector;
using MySqlExample.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MySqlExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MySqlConnection _connection;

        public HomeController(ILogger<HomeController> logger, MySqlConnection connection)
        {
            _logger = logger;
            _connection = connection;
        }

        public IActionResult Index()
        {
            // Reading from db
            _connection.Open();

            List<GuestModel> models = new();

            using var command = new MySqlCommand("SELECT * FROM myguests;", _connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                GuestModel model = new()
                {
                    Id = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Email = reader.GetString(3),
                    Date = reader.GetDateTime(4)
                };

                models.Add(model);
                var value = reader.GetValue(3);
                // do something with 'value'
            }

            _connection.Close();

            _connection.Open();

            // Insert
            using var command2 = new MySqlCommand(
            " insert into myguests (firstname, lastname, email) values('test3', 'test3', 'testemail3')", _connection);
            command2.ExecuteNonQuery();


            _connection.Close();


            return View();
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
