using System;

namespace SampleApp.Domain.Users.Models
{
    public class UserDetails
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string BirthDate { get; set; } = null!;
    }
}
