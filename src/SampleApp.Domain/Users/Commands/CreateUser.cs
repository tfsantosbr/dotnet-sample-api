using SampleApp.Domain.Users.Validators;
using SampleApp.Shared.Notifications;
using System;

namespace SampleApp.Domain.Commands
{
    public class CreateUser : Notifiable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public DateTime BirthDate { get; set; }

        public override bool IsValid()
        {
            Validate(new CreateUserValidator());

            return !HasNotifications;
        }
    }
}
