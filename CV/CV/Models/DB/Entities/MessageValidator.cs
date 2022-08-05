using FluentValidation;

namespace CV.Models.DB.Entities
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.Text)
                .Length(15, 250)
                .WithMessage("Text must be between 2 to 50 words");
        }
    }
}
