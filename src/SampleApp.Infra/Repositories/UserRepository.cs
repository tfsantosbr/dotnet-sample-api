﻿using SampleApp.Domain.Users.Repository;
using SampleApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using SampleApp.Domain.Core.ValueObjects;

namespace SampleApp.Domain.Users.Repository
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users = new();

        public void Add(User user)
        {
            _users.Add(user);
        }

        public User GetById(Guid id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public void Update(User user)
        {
            var currentUser = GetById(user.Id);

            if (currentUser != null) currentUser = user;
        }

        public bool AnyUser(Guid userId)
        {
            return _users.Any(u => u.Id == userId);
        }

        public void Remove(User user)
        {
            _users.Remove(user);
        }

        public bool AnyEmail(Email email, Guid ignoredUserId)
        {
            return _users.Any(u =>
                u.Email.Address == email.Address &&
                u.Id != ignoredUserId
                );
        }
    }
}
