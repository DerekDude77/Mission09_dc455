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
        public IActionResult Purchase()
        {
            return View(new Checkout());
        }
    }
}
