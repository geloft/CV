using FluentValidation;

namespace CV.Models.DB.Entities
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
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
        }
    }
}
