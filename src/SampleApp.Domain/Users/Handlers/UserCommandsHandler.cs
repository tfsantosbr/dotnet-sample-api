using SampleApp.Domain.Users.Commands;
using SampleApp.Domain.Users.Events;
using SampleApp.Domain.Users.Repository;
using SampleApp.Domain.Entities;
using System;
using SampleApp.Domain.Commands;
using SampleApp.Shared.Notifications.Interfaces;
using SampleApp.Domain.Core.ValueObjects;
using SampleApp.Shared.Notifications;

namespace SampleApp.Domain.Users.Handlers
{
    public class UserCommandsHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly INotifier _notifier;
        private readonly UserEventsHandler _userEventsHandler;

        public UserCommandsHandler(IUserRepository userRepository, UserEventsHandler userEventsHandler, INotifier notifier)
        {
            _userRepository = userRepository;
            _userEventsHandler = userEventsHandler;
            _notifier = notifier;
        }

        public User? Handle(CreateUser request)
        {
            // validations

            if (!request.IsValid())
            {
                _notifier.AddNotifications(request.GetNotifications());
                return null;
            }

            // business logics

            var user = new User(
                completeName: new CompleteName(request.FirstName, request.LastName),
                email: new Email(request.Email),
                password: new Password(request.Password),
                birthDate: request.BirthDate
                );

            if (_userRepository.AnyEmail(user.Email, user.Id))
            {
                _notifier.AddNotification(new Notification("Email", $"E-mail '{user.Email}' alread exists."));
                return null;
            }

            _userRepository.Add(user);

            // send event

            var userCreated = new UserCreated
            {
                Id = user.Id,
                FirstName = user.CompleteName.FirstName,
                LastName = user.CompleteName.LastName,
                BirthDate = user.BirthDate,
                Email = user.Email.Address,
                Password = user.Password.Value
            };

            _userEventsHandler.Handle(userCreated);

            return user;
        }

        public void Handle(UpdateUserDetails request)
        {
            // validations

            if (!request.IsValid())
            {
                _notifier.AddNotifications(request.GetNotifications());
                return;
            }

            // business logic

            var user = _userRepository.GetById(request.UserId);

            if (user is null)
                throw new NullReferenceException(nameof(user));

            user.UpdateDetails(
                completeName: new CompleteName(request.FirstName, request.LastName)
            );

            _userRepository.Update(user);

            // send event

            var userDetailsUpdated = new UserDetailsUpdated
            {
                Id = user.Id,
                FirstName = user.CompleteName.FirstName,
                LastName = user.CompleteName.LastName,
                BirthDate = user.BirthDate,
                Email = user.Email.Address
            };

            _userEventsHandler.Handle(userDetailsUpdated);
        }

        public void Handle(UpdateUserPassword request)
        {
            // validations

            if (!request.IsValid())
            {
                _notifier.AddNotifications(request.GetNotifications());
                return;
            }

            // business logic

            var user = _userRepository.GetById(request.UserId);

            if (user is null)
                throw new NullReferenceException(nameof(user));

            user.UpdatePassword(new Password(request.Password));

            _userRepository.Update(user);

            // send event

            var userPasswordUpdated = new UserPasswordUpdated
            {
                Id = user.Id,
                Password = user.Password.Value
            };

            _userEventsHandler.Handle(userPasswordUpdated);
        }

        public void Handle(RemoveUser request)
        {
            // validations

            var user = _userRepository.GetById(request.UserId);

            if (user is null)
                throw new NullReferenceException(nameof(user));

            _userRepository.Remove(user);

            // send event

            var userRemoved = new UserRemoved
            {
                Id = user.Id
            };

            _userEventsHandler.Handle(userRemoved);
        }
    }
}
