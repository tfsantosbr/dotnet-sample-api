using SampleApp.Domain.Users.Validators;
using SampleApp.Shared.Notifications;
using System;

namespace SampleApp.Domain.Commands
{
    public class CreateUser : Notifiable
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string ConfirmPassword { get; set; } = null!;
        public DateTime BirthDate { get; set; }

        public override bool IsValid()
        {
            Validate(new CreateUserValidator());

            return !HasNotifications;
        }
    }
}
