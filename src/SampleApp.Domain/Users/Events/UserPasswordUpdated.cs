using System;

namespace SampleApp.Domain.Users.Events
{
    public class UserPasswordUpdated
    {
        public Guid Id { get; set; }
        public string Password { get; set; } = null!;
    }
}
