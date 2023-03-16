using Microsoft.AspNetCore.Mvc;
using Mission09_dc455.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_dc455.Controllers
{
    public class CheckoutController : Controller
    {
        private ICheckoutRepository repo { get; set; }
        private Cart cart { get; set; }
        public CheckoutController (ICheckoutRepository temp, Cart c)
        {
            repo = temp;
            cart = c;
        }

        [HttpGet]
        public IActionResult Purchase()
        {
            return View(new Checkout());
        }

        [HttpPost]
        public IActionResult Purchase(Checkout checkout)
        {
            if (cart.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Your cart is empty");
            }

            if (ModelState.IsValid)
            {
                checkout.Lines = cart.Items.ToArray();
                repo.SaveCheckout(checkout);
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
