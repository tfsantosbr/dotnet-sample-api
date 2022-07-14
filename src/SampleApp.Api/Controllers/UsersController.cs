using Microsoft.AspNetCore.Mvc;
using SampleApp.Domain.Commands;
using SampleApp.Domain.Users.Commands;
using SampleApp.Domain.Users.Handlers;
using SampleApp.Domain.Users.Models;
using SampleApp.Domain.Users.Repository;
using SampleApp.Shared.Notifications;
using SampleApp.Shared.Notifications.Interfaces;
using System;

namespace SampleApp.Api.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly UserCommandsHandler _handler;
        private readonly IUserRepository _userRepository;
        private readonly INotifier _notifier;

        public UsersController(UserCommandsHandler handler, IUserRepository userRepository, INotifier notifier)
        {
            _handler = handler;
            _userRepository = userRepository;
            _notifier = notifier;
        }

        [HttpPost]
        public IActionResult CreateUser(CreateUser request)
        {
            var user = _handler.Handle(request);

            if (user is null || _notifier.HasNotifications())
            {
                return UnprocessableEntity(_notifier.GetNotifications());
            }

            var userDetails = new UserDetails
            {
                Id = user.Id,
                FirstName = user.CompleteName.FirstName,
                LastName = user.CompleteName.LastName,
                BirthDate = $"{user.BirthDate:yyyy-MM-dd}",
                Email = user.Email.Address
            };

            return Created($"users/{userDetails.Id}", userDetails);
        }

        [HttpGet]
        public IActionResult GetUserById(Guid userId)
        {
            var user = _userRepository.GetById(userId);

            if (user is null)
                return NotFound();

            var userDetails = new UserDetails
            {
                Id = user.Id,
                FirstName = user.CompleteName.FirstName,
                LastName = user.CompleteName.LastName,
                BirthDate = $"{user.BirthDate:yyyy-MM-dd}",
                Email = user.Email.Address
            };

            return Ok(userDetails);
        }

        [HttpDelete("{userId}")]
        public IActionResult RemoveUser(Guid userId)
        {
            if (!_userRepository.AnyUser(userId))
            {
                return NotFound(new Notification("User", "User not found"));
            }

            _handler.Handle(new RemoveUser { UserId = userId });

            return NoContent();
        }

        [HttpPut("{userId}/details")]
        public IActionResult UpdateUserDetails(Guid userId, UpdateUserDetails request)
        {
            if (!_userRepository.AnyUser(userId))
            {
                return NotFound(new Notification("User", "User not found"));
            }

            request.UserId = userId;

            _handler.Handle(request);

            if (_notifier.HasNotifications())
            {
                return UnprocessableEntity(_notifier.GetNotifications());
            }

            return NoContent();
        }

        [HttpPut("{userId}/password")]
        public IActionResult UpdateUserPassword(Guid userId, UpdateUserPassword request)
        {
            if (!_userRepository.AnyUser(userId))
            {
                return NotFound(new Notification("User", "User not found"));
            }

            request.UserId = userId;

            _handler.Handle(request);

            if (_notifier.HasNotifications())
            {
                return UnprocessableEntity(_notifier.GetNotifications());
            }

            return NoContent();
        }
    }
}
