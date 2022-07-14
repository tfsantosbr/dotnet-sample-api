using System;
using SampleApp.Domain.Core.ValueObjects;
using SampleApp.Domain.Entities;

namespace SampleApp.Domain.Users.Repository
{
    public interface IUserRepository
    {
        void Add(User user);
        User? GetById(Guid id);
        void Update(User user);
        bool AnyUser(Guid userId);
        void Remove(User user);
        bool AnyEmail(Email email, Guid ignoredUserId);
    }
}
