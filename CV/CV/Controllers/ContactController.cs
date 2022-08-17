using Microsoft.AspNetCore.Mvc;
using CV.Models;
using CV.Models.ViewModels;
using CV.Models.DB.Entities;

namespace CV.Controllers
{
    public class ContactController : Controller
    {
        private readonly UserContext _context;

        public ContactController(UserContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            var user = new User { FirstName = model.FirstName, LastName = model.LastName, Email = model.Email };
            if (ModelState.IsValid)
            {
                if (_context.Users.Where(x => x.Email == user.Email).FirstOrDefault() == null)
                {
                    _context.Users.Add(user);
                }
                else
                {
                    user = _context.Users.Where(x => x.Email == user.Email).FirstOrDefault();
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;                    
                }
                _context.Messages.Add(new Message() { Text = model.Text, User = user });
                _context.SaveChanges();
                return View("Send", model);
            }          
            return View();
        }

        public IActionResult Send(ContactViewModel model)
        {
            return View(model);
        }
    }
}
