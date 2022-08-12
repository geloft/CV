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
            if (ModelState.IsValid)
            {
                if (_context.Users.Where(x => x.Email == model.Email).Count() == 0)
                {
                    _context.Users.Add(new User() { Email = model.Email, FirstName = model.FirstName, LastName = model.LastName });
                    _context.SaveChanges();
                    _context.Messages.Add(new Message() { Text = model.Text, UserID = _context.Users.ToList().Last().UserID });
                    _context.SaveChanges();
                    return View("Send", model);
                }
                else
                {
                    _context.Messages.Add(new Message() { Text = model.Text, UserID = _context.Users.Where(x => x.Email == model.Email).First().UserID });
                    _context.SaveChanges();
                    return View("Send", model);
                }
            }
            return View();
        }

        public IActionResult Send(ContactViewModel model)
        {
            return View(model);
        }
    }
}
