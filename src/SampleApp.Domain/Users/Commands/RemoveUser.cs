using System;
using System.Text.Json.Serialization;

namespace SampleApp.Domain.Users.Commands
{
    public class RemoveUser
    {
        [JsonIgnore]
        public Guid UserId { get; set; }
    }
}