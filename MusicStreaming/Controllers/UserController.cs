using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicStreaming.Models.Database;
using MusicStreaming.Models.ViewModel;
using System.Linq;

namespace MusicStreaming.Controllers
{
    public class UserController : Controller
    { 

        private readonly MusicStreamingContext _context;
        public UserController(MusicStreamingContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult Login([FromBody] User requestUser)
        {
            var user = _context.Users.FirstOrDefault(user => user.Email == requestUser.Email && user.Password == requestUser.Password);
            if(user != null)
            {
                HttpContext.Session.SetInt32("UserId", user.Id);
                return Ok(user);
            }
            return Unauthorized();
        }
        public IActionResult Balance()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            var user = _context.Users.FirstOrDefault(user => user.Id == userId);
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var balance = new BalanceView
            {
                Balance = user.Balance != null ? user.Balance : 0
            };
            return View(balance);
        }
        [HttpPost]
        public IActionResult Balance([FromForm] BalanceView vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Result = "Invalid input(s)";
            }
            else
            {
                var userId = HttpContext.Session.GetInt32("UserId");
                var user = _context.Users.FirstOrDefault(user => user.Id == userId);
                if(user == null)
                {
                    return RedirectToAction("Error", "Home");
                }
                if(user.Balance == null)
                {
                    user.Balance = 0;
                }
                user.Balance += vm.Amount;
                _context.Update(user);
                _context.SaveChanges();
                vm.Balance = user.Balance;
                vm.Result = "Funds Added";
            }
            return View("Balance", vm);
        }
    }
}
