using SampleApp.Domain.Commands;
using SampleApp.Domain.Users.Commands;
using System;
using Xunit;

namespace SampleApp.Tests.Commands
{
    public class CreateUserTests
    {
        [Fact]
        public void ShouldMarkAsInvalidWhenCreateUserWithInvalidData()
        {
            // arrange

            var command = new CreateUser
            {
                FirstName = "",
                LastName = "",
                Email = "",
                Password = "",
                ConfirmPassword = ""
            };

            // act & assert

            Assert.False(command.IsValid());
        }

        [Fact]
        public void ShouldMarkAsValidWhenCreateUserWithValidData()
        {
            // arrange

            var command = new CreateUser
            {
                FirstName = "Tiago",
                LastName = "Santos",
                Email = "tiago@email.com",
                Password = "Passw0rd",
                ConfirmPassword = "Passw0rd",
                BirthDate = new DateTime(1987, 3, 13)
            };

            // act & assert

            Assert.True(command.IsValid());
        }
    }
}
