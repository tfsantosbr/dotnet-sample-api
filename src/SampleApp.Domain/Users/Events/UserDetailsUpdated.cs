using System;

namespace SampleApp.Domain.Users.Events
{
    public class UserDetailsUpdated
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
    }
}