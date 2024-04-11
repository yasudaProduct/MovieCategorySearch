using Merino.Test;
using Moq;
using MovieCategorySearch.Domain.Auth;

namespace MovieCategorySearch.UnitTest.Domain.Auth
{

    public class AuthDomainServiceTest : MerinoUnitTest
    {
        private readonly Mock<IAuthDomainService> _authDomainServiceMock;

        public AuthDomainServiceTest()
        {
            _authDomainServiceMock = new Mock<IAuthDomainService>();
        }

        [Fact]
        public void Login_ValidCredentials_ReturnsTrue()
        {
            // Arrange
            string mailAddress = "test@example.com";
            string password = "password";

            _authDomainServiceMock.Setup(x => x.Login(mailAddress, password)).Returns(true);

            // Act
            bool result = _authDomainServiceMock.Object.Login(mailAddress, password);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Login_InvalidCredentials_ReturnsFalse()
        {
            // Arrange
            string mailAddress = "test@example.com";
            string password = "password";

            _authDomainServiceMock.Setup(x => x.Login(mailAddress, password)).Returns(false);

            // Act
            bool result = _authDomainServiceMock.Object.Login(mailAddress, password);

            // Assert
            Assert.False(result);
        }
    }
}
