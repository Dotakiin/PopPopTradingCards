using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PopPopTradingCardsWebUI.Models;
using PopPopTradingCardsLib.Interfaces;
using PopPopTradingCardsDataAccess.Entities;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace PopPopTradingCardsWebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository _repo;

        public HomeController(IRepository repo, ILogger<HomeController> logger)
        {
            _logger = logger;
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public ActionResult LoginAction(User u, IFormCollection form)
        {
            int id = 0;
            id = _repo.Login(u.Username, u.Password);
            if(id!=0)
            {
                HttpContext.Session.SetString("Username", u.Username);
                HttpContext.Session.SetInt32("Id", id);
                TempData["Username"] = JsonConvert.SerializeObject(u.Username);
                TempData["Id"] = JsonConvert.SerializeObject(id);
                return View("Index");
            }
            else
            {
                ViewData["LoginStatus"] = "Invalid username or password";
                return View("Login");
            }
        }
        public IActionResult Signup()
        {
            return View();
        }
        public ActionResult SignupAction(User u, IFormCollection form)
        {
            bool valid = _repo.CheckAvailability(u.Username);
            if (valid)
            {
                _repo.CreateAccount(u.Username, u.Password);
                return View("Index");
            }
            else
            {
                ViewData["SignupStatus"] = "That Username is unavailable.";
                return View("Signup");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Search(string searchString = null)
        {
            // Get all users whose name contains the search string
            var userResults = (string.IsNullOrEmpty(searchString))
                ? _repo.GetAllUsers()
                : _repo.GetAllUsers().Where(u => u.Username.Contains(searchString));

            // Get all users who are not the current user
            userResults = userResults.Where(u => u.Username != HttpContext.Session.GetString("Username"));

            return View(userResults);
        }

        //[HttpGet]
        //public /*async Task<IActionResult>*/ IActionResult SearchForUsers(string searchString = null)
        //{
        //    ViewData["UserSearch"] = searchString;

        //    var userResults = (string.IsNullOrEmpty(searchString))
        //        ? _repo.GetAllUsers()
        //        : _repo.GetAllUsers().Where(u => u.Username.Contains(searchString));

        //    return View("Search", userResults);
        //}
    }
}
