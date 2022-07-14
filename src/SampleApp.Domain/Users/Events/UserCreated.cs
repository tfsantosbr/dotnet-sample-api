using System;

namespace SampleApp.Domain.Users.Events
{
    public class UserCreated
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime BirthDate { get; set; }
    }
}
