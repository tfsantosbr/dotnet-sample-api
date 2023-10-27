using SampleApp.Domain.Users.Repository;
using SampleApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using SampleApp.Domain.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using SampleApp.Infra.Contexts;

namespace SampleApp.Domain.Users.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly SampleAppContext _context;

        public UserRepository(SampleAppContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User? GetById(Guid id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public bool AnyUser(Guid userId)
        {
            return _context.Users.Any(u => u.Id == userId);
        }

        public void Remove(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public bool AnyEmail(Email email, Guid ignoredUserId)
        {
            return _context.Users.ToArray().Any(u =>
                u.Email.Address == email.Address &&
                u.Id != ignoredUserId
                );
        }
    }
}
