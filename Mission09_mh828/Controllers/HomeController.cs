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
        public IActionResult Index(string category, int pageNum = 1)
        {
            // pageSize Variable Initialization
            int pageSize = 10;

            var returnList = new BooksViewModel
            {
                // Grabbing Books from DB for each page
                Books = repo.Books
                .Where(b => b.Category == category || category == null)
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                // Creating PageInfo fo BooksViewModel
                PageInfo = new PageInfo
                {
                    TotalNumBooks = (category == null 
                    ? repo.Books.Count() 
                    : repo.Books.Where(x => x.Category == category).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(returnList);
        }
    }
}
