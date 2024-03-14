using Microsoft.AspNetCore.Mvc;
using CV.Models;
using CV.Models.ViewModels;
using CV.Models.DB.Entities;
using CV.Services;

namespace CV.Controllers
{
    public class ContactController : Controller
    {
        private readonly UserContext _context;
        private readonly IEmailSender _emailSender;

        public ContactController(UserContext context, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Contact(ContactViewModel model)
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

            string email = "grisha.kutyanski@gmail.com";
            string subject = "Сповіщення з сайту MyCV";
            string message = $"З вами хоче зв'язатись {model.FirstName} {model.LastName}\nEmail: {model.Email} \nТекст повідомлення: {model.Text}";
            await _emailSender.SendEmailAsync(email, subject, message);

            return View("Send", model);
        }

        public IActionResult Send(ContactViewModel model)
        {
            return View(model);
        }
    }
}
