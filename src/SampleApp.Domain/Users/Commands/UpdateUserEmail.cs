using SampleApp.Domain.Users.Validators;
using SampleApp.Shared.Notifications;
using System;
using System.Text.Json.Serialization;

namespace SampleApp.Domain.Commands
{
    public class UpdateUserEmail : Notifiable
    {
        [JsonIgnore]
        public Guid UserId { get; set; }
        public string Email { get; set; }

        public override bool IsValid()
        {
            Validate(new UpdateUserEmailValidator());

            return !HasNotifications;
        }
    }
}
