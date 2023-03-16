﻿using Microsoft.AspNetCore.Mvc;
using Mission09_mh828.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_mh828.Controllers
{
    public class PurchaseController : Controller
    {
        private IPurchaseRepository repo { get; set; }
        private Cart cart { get; set; }
        public PurchaseController(IPurchaseRepository temp, Cart c)
        {
            repo = temp;
            cart = c;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Purchase());
        }

        [HttpPost]
        public IActionResult Checkout(Purchase p)
        {
            if (cart.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }

            if (ModelState.IsValid)
            {
                p.Lines = cart.Items.ToArray();
                repo.SavePurchase(p);
                cart.ClearCart();

                return RedirectToPage("/PurchaseCompleted");
            }
            else
            {
                return View();
            }
        }
    }
}
