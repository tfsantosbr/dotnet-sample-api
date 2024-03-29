﻿using SampleApp.Domain.Users.Validators;
using SampleApp.Shared.Notifications;
using System;
using System.Text.Json.Serialization;

namespace SampleApp.Domain.Commands
{
    public class UpdateUserDetails : Notifiable
    {
        [JsonIgnore]
        public Guid UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public override bool IsValid()
        {
            Validate(new UpdateUserDetailsValidator());

            return !HasNotifications;
        }
    }
}
