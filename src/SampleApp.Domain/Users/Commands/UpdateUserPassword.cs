﻿using SampleApp.Domain.Users.Validators;
using SampleApp.Shared.Notifications;
using System;
using System.Text.Json.Serialization;

namespace SampleApp.Domain.Commands
{
    public class UpdateUserPassword : Notifiable
    {
        [JsonIgnore]
        public Guid UserId { get; set; }
        public string Password { get; set; } = null!;
        public string ConfirmPassword { get; set; } = null!;

        public override bool IsValid()
        {
            Validate(new UpdateUserPasswordValidator());

            return !HasNotifications;
        }
    }
}
