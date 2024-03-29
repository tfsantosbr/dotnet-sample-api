﻿using SampleApp.Domain.Core.ValueObjects;
using SampleApp.Domain.Users.Validators;
using SampleApp.Shared.Notifications;
using System;

namespace SampleApp.Domain.Entities
{
    public class User : Notifiable
    {
        public User(CompleteName completeName, Email email, Password password, DateTime birthDate, Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
            CompleteName = completeName;
            Email = email;
            Password = password;
            BirthDate = birthDate;

            EnsureValidation();
        }

        private User()
        {
        }

        public Guid Id { get; private set; }
        public CompleteName CompleteName { get; private set; } = default!;
        public DateTime BirthDate { get; private set; }
        public Email Email { get; private set; } = default!;
        public Password Password { get; private set; } = default!;

        public void UpdateDetails(CompleteName completeName)
        {
            CompleteName = completeName;
        }

        public void UpdatePassword(Password password)
        {
            Password = password;
        }

        public void UpdateEmail(Email email)
        {
            Email = email;
        }

        public override bool IsValid()
        {
            Validate(new UserValidator());

            return !HasNotifications;
        }
    }
}
