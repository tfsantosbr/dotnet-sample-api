using FluentValidation;
using SampleApp.Domain.Commands;

namespace SampleApp.Domain.Users.Validators
{
    public class UpdateUserEmailValidator : AbstractValidator<UpdateUserEmail>
    {
        public UpdateUserEmailValidator()
        {
            RuleFor(p => p.Email).NotEmpty().Length(2, 150).EmailAddress();
        }
    }
}
