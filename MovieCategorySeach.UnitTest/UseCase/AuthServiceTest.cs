using Merino.Test;
using Moq;
using MovieCategorySearch.Domain.User;
using MovieCategorySearch.Application.UseCase.Auth;
using MovieCategorySearch.Application.UseCase.Auth.Dto;
using MovieCategorySearch.Domain.User.ValueObject;


namespace MovieCategorySeach.UnitTest.UseCase
{

    /// <summary>
    /// ユーザー認証サービスのテストクラスです。
    /// </summary>
    public class AuthServiceTest : MerinoUnitTest
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly AuthService _authService;

        /// <summary>
        /// AuthServiceTest クラスの新しいインスタンスを初期化します。
        /// </summary>
        public AuthServiceTest()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _authService = new AuthService(_userRepositoryMock.Object);
        }

        /// <summary>
        /// ユーザーが存在する場合、Auth メソッドは true を返します。
        /// </summary>
        [Fact]
        public void Auth_WhenUserExists_ReturnsTrue()
        {
            // Arrange
            var authRequest = new AuthRequest("unittest@example.com", "password");
            var user = new User(1, "Unit Test", new EmailAddress("unittest@example.com"), UserCls.Normal);
            _userRepositoryMock.Setup(repo => repo.Find(authRequest.LoginId)).Returns(user);

            // Act
            var result = _authService.Auth(authRequest);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        /// ユーザーが存在しない場合、Auth メソッドは false を返します。
        /// </summary>
        [Fact]
        public void Auth_WhenUserDoesNotExist_ReturnsFalse()
        {
            // Arrange
            var authRequest = new AuthRequest("unittest@example.com", "password");
            _userRepositoryMock.Setup(repo => repo.Find(authRequest.LoginId)).Returns((User)null);

            // Act
            var result = _authService.Auth(authRequest);

            // Assert
            Assert.False(result);
        }
    }
}
