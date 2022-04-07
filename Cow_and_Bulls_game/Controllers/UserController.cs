using Cow_and_Bulls_game.Models;
using Cow_and_Bulls_game.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace Cow_and_Bulls_game.Controllers
{
    public class UserController : Controller
    {
        private MyAppDbContext _context;    
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Signup()
        {
            return View();
        }
        public IActionResult HomePage()
        {
            return View();
        }


        public IActionResult AuthenticateUser(UserGameViewModel obj)
        {
            _context = new MyAppDbContext();

            var result = _context.Users.Where(u => u.UserId == obj.user.UserId && u.Password == obj.user.Password);
            if(result.Count() > 0)
            {
                return RedirectToActionPermanent("GamePage", "Game");
            }
            else
            {
                var AuthFailed = new UserGameViewModel();
                AuthFailed.errorMessage = "Please Enter valid username/password";
                return View(AuthFailed);
            }
            
        }
        public IActionResult AddUser(User user)
        {
            _context = new MyAppDbContext();
            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToActionPermanent("Login", "User");
        }
        
    }
}
