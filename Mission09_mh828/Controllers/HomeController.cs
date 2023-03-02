using Microsoft.AspNetCore.Mvc;
using Mission09_mh828.Models;
using Mission09_mh828.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_mh828.Controllers
{
    public class HomeController : Controller
    {
        // Repo Initiation
        private IBookRepository repo;

        // Constructor
        public HomeController (IBookRepository temp)
        {
            repo = temp;
        }

        // Index Route and Model Passing
        public IActionResult Index(int pageNum = 1)
        {
            // pageSize Variable Initialization
            int pageSize = 10;

            var returnList = new BooksViewModel
            {
                // Grabbing Books from DB for each page
                Books = repo.Books
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                // Creating PageInfo fo BooksViewModel
                PageInfo = new PageInfo
                {
                    TotalNumBooks = repo.Books.Count(),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(returnList);
        }
    }
}
