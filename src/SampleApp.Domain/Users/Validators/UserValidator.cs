using FluentValidation;
using SampleApp.Domain.Entities;

namespace SampleApp.Domain.Users.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.CompleteName).NotEmpty();
            RuleFor(p => p.Email).NotEmpty();
            RuleFor(p => p.Password).NotEmpty();
            RuleFor(p => p.BirthDate).NotEmpty();
        }
    }
}
