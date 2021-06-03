using SampleApp.Domain.Core.ValueObjects.Validators;
using SampleApp.Shared.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.Domain.Core.ValueObjects
{
    public class Password : Notifiable
    {
        public Password(string value)
        {
            Value = value;

            EnsureValidation();
        }

        public string Value { get; private set; }

        public override bool IsValid()
        {
            Validate(new PasswordValidator());

            return !HasNotifications;
        }
    }
}
