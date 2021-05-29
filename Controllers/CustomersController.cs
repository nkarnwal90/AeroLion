using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AeroLion.Models;
using Microsoft.AspNetCore.Mvc;

namespace AeroLion.Controllers
{
    public class CustomersController : Controller
    {
        customers Customers;
        private readonly dbcontext _context;

        public CustomersController(dbcontext context)
        {
            Customers = new customers();
            _context = context;
        }
        [HttpGet]
       public ActionResult RegisterCustomer()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> RegisterCustomer(customers Params)
        {
            Params.Id = Guid.NewGuid().ToString();//AeroLion@123
            Params.password = StockStackApi.Security.Crypto.Encrypt(Params.password);
            Params.is_admin = false;
            _context.Add(Params);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(RegisterCustomer));
        }
    }
}
