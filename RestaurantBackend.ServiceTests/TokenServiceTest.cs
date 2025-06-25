using AutoFixture;
using FluentAssertions;
using Moq;
using Restaurant.Core.Domain.IdentityEntities;
using Restaurant.Core.Services;
using Restaurant.Core.ServicesContracts;
using Restaurant.Core.Token;
using RestaurantBackend.ServiceTests.CustomFixtureConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantBackend.ServiceTests
{
    public class TokenServiceTest
    {
        private readonly IFixture _fixture;
        private readonly Mock<IProfileService> _profileServiceMock;
        private readonly Mock<ITokenService> _tokenServiceMock;
        private readonly RefreshTokenUseCase _refreshTokenUseCase;

        public TokenServiceTest()
        {
            _profileServiceMock = new Mock<IProfileService>();
            _tokenServiceMock = new Mock<ITokenService>();

            _refreshTokenUseCase = new RefreshTokenUseCase(
                _profileServiceMock.Object,
                _tokenServiceMock.Object
            );

            _fixture = FixtureFactory.Create();
        }

        [Fact]
        public async Task HandleRefresh_ShouldReturnNewToken_WhenRefreshTokenIsValid()
        {
            var refreshToken = "valid-token";
            var user = _fixture.Create<ApplicationUser>();
            var newToken = _fixture.Create<TokenResponse>();

            _profileServiceMock.Setup(p => p.GetUserByRefreshToken(refreshToken))
                .ReturnsAsync(user);

            _profileServiceMock.Setup(p => p.IsRefreshTokenValid(user, refreshToken))
                .ReturnsAsync(true);

            _tokenServiceMock.Setup(t => t.CreateJwtToken(user))
                .Returns(newToken);

            _profileServiceMock.Setup(p => p.SaveRefreshToken(user, newToken.RefreshToken))
                .Returns(Task.CompletedTask);

            var result = await _refreshTokenUseCase.HandleRefresh(refreshToken);

            result.Should().BeEquivalentTo(newToken);
        }

        [Fact]
        public async Task HandleRefresh_ShouldThrowUnauthorized_WhenTokenIsInvalid()
        {
            var refreshToken = "invalid-token";

            _profileServiceMock.Setup(p => p.GetUserByRefreshToken(refreshToken))
                .ReturnsAsync((ApplicationUser)null);

            Func<Task> act = async () => await _refreshTokenUseCase.HandleRefresh(refreshToken);

            await act.Should().ThrowAsync<UnauthorizedAccessException>();
        }

        [Fact]
        public async Task HandleRefresh_ShouldThrowArgumentNullException_WhenTokenIsNull()
        {
            Func<Task> act = async () => await _refreshTokenUseCase.HandleRefresh(null);

            await act.Should().ThrowAsync<ArgumentNullException>();
        }
    }
}
