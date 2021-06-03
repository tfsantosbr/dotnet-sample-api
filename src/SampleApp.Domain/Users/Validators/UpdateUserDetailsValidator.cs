using FluentValidation;
using SampleApp.Domain.Commands;

namespace SampleApp.Domain.Users.Validators
{
    public class UpdateUserDetailsValidator : AbstractValidator<UpdateUserDetails>
    {
        public UpdateUserDetailsValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty().Length(2, 150);
            RuleFor(p => p.LastName).NotEmpty().Length(2, 150);
        }
    }
}
