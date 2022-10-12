using ATM_Application.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

namespace ATM_Application.Controllers
{
    public class HomeController : Controller
    {
        // Get Connection String
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        SqlConnection con = new SqlConnection();
        List<User> users = new List<User>();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            con.ConnectionString = "Data Source=DESKTOP-E93ERMF\\SQLEXPRESS; Integrated Security=true;Initial Catalog= ATM;";
        }
        
        public IActionResult Index()
        {
            FetchData();
            return View(users);
        }

        public void FetchData()
        {
            if(users.Count > 0)
            {
                users.Clear();
            }
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT TOP (1000) [id],[name],[amount] FROM [ATM].[dbo].[Users]";
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    users.Add(new User() {id = dr["id"].ToString()
                        ,name = dr["name"].ToString()
                        ,amount = dr["amount"].ToString(),
                    });
                }
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
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