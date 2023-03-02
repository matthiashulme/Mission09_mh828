using Microsoft.AspNetCore.Mvc;
using Mission09_mh828.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_mh828.Controllers
{
    public class HomeController : Controller
    {
        private IBookRepository repo;

        public HomeController (IBookRepository temp)
        {
            repo = temp;
        }
        public IActionResult Index()
        {
            var returnList = repo.Books.ToList();

            return View(returnList);
        }
    }
}
