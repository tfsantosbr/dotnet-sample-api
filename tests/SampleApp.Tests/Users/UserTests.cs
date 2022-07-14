using SampleApp.Domain.Core.ValueObjects;
using SampleApp.Domain.Entities;
using Xunit;

namespace SampleApp.Tests.Users
{
    public class UserTests
    {
        [Fact]
        public void ShouldThrowAnExceptionWhenInstanceUserWithInvalidData()
        {
            // arrange

            static void createUser() => new User(
                completeName: new CompleteName(string.Empty, string.Empty),
                email: new Email(string.Empty),
                password: new Password(string.Empty),
                birthDate: new DateTime()
                );

            // act

            var exception = Record.Exception(createUser);

            // assert

            Assert.IsType<InvalidOperationException>(exception);
        }

        [Fact]
        public void ShouldBeValidUserWhencreatedWithValidData()
        {
            // arrange

            var user = new User(
                completeName: new CompleteName("Tiago", "Santos"),
                email: new Email("tiago@email.com"),
                password: new Password("PaSsW0rd"),
                birthDate: new DateTime(1987, 3, 13)
                );

            // act

            var isValid = user.IsValid();

            // assert

            Assert.True(isValid);
        }
    }
}
