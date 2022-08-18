using FluentValidation;

namespace CV.Models.ViewModels
{
    public class ContactViewModelValidator : AbstractValidator<ContactViewModel>
    {
        public ContactViewModelValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First Name is required");
            RuleFor(x => x.FirstName)
                .Length(2, 50)
                .WithMessage("First Name must be between 2 to 50 words");

            RuleFor(x => x.LastName)
               .NotEmpty()
               .WithMessage("Last Name is required");
            RuleFor(x => x.LastName)
                .Length(2, 50)
                .WithMessage("Last Name must be between 2 to 50 words");

            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("Email is required");

            RuleFor(x => x.Text)
                .Length(15, 250)
                .WithMessage("Text must be between 15 to 250 chars");
        }
    }
}
