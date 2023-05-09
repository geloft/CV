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
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = _context.Users.FirstOrDefault(x => x.Email == model.Email);
            if (user == null)
            {
                _context.Users.Add(user = new User { FirstName = model.FirstName, LastName = model.LastName, Email = model.Email });
            }
            else
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
            }
            _context.Messages.Add(new Message() { Text = model.Text, User = user });
            _context.SaveChanges();
            return View("Send", model);
        }

        public IActionResult Send(ContactViewModel model)
        {
            return View(model);
        }
    }
}
