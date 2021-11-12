using airline.management.application.Abstractions.BusinessProcess;
using airline.management.domain.Entities;
using airline.management.infrastructure.BusinessProcess;
using airline.management.infrastructure.Persistence.Context;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace airline.management.infrastructure.test.BusinessProcess
{
    public class ManageTokenTests : IDisposable
    {
        private readonly IManageToken _manageToken;
        private const string jwtSecret = "rT0-Rw1OhW02cDHdy7PLTBdHl-eaGil94Way7hK-suk";
        private const string expiredToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJJZCI6Ijk1ZWY1ZmY2LWZmZTAtNDNkYS1iMjcwLTkwYjRiMzE4NmIwMCIsImVtYWlsIjoicWFzaW1AYWJjLmNvbSIsInN1YiI6InFhc2ltQGFiYy5jb20iLCJqdGkiOiIzZTkzN2Y5Yy0wMTRkLTQwMmEtYmRlYi1lNjE3YWJhM2E3ZmEiLCJuYmYiOjE2MzY2NDEwODksImV4cCI6MTYzNjY0MTE0OSwiaWF0IjoxNjM2NjQxMDg5fQ.tplZbU5rZ2BD40WiCiqtbGyShqYHgf0ztn7kU7nY1cE";
        private readonly GatewayDbContext _gatewayDbContext;

        public ManageTokenTests()
        {
            var userStore = Substitute.For<IUserStore<IdentityUser>>();
            var userManager = Substitute.For<UserManager<IdentityUser>>(userStore, null, null, null, null, null, null, null, null);

            var jwtOptions = Options.Create(new JwtConfig
            {
                ExpiryInMinutes = 1,
                Secret = jwtSecret
            });

            // Install-Package Microsoft.EntityFrameworkCore.InMemory
            var options = new DbContextOptionsBuilder<GatewayDbContext>()                
                .UseInMemoryDatabase(databaseName: "GatewayDatabase")
                .Options;

            _gatewayDbContext = new GatewayDbContext(options);

            var key = Encoding.ASCII.GetBytes(jwtSecret);

            var tokenValidationParams = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            _manageToken = new ManageToken(userManager, jwtOptions, tokenValidationParams, _gatewayDbContext);
        }

        [Fact]
        public async Task GenerateJwtToken_ShouldReturnRegistrationResponseDto_ReturnSuccessful()
        {
            // Arrange
            var user = new IdentityUser
            {
                Email = "qasim@abc.com",
                Id = Guid.NewGuid().ToString()
            };

            // Act
            var result = await _manageToken.GenerateJwtToken(user);

            // Assert
            result.Token.Should().NotBeNull();

            result.RefreshToken.Should().NotBeNull();

            result.Success.Should().BeTrue();

            result.Errors.Should().BeEquivalentTo(null);
        }

        [Fact]
        public async Task GetUserClaims_ShouldReturnUserClaims_ReturnSuccessful()
        {
            // Arrange
            var user = new IdentityUser
            {
                Email = "qasim@abc.com",
                Id = Guid.NewGuid().ToString()
            };

            var response = await _manageToken.GenerateJwtToken(user);

            // Act
            var result = _manageToken.GetUserClaims(response.Token);

            // Assert
            result.EmailAddress.Should().BeEquivalentTo(user.Email);

            result.Success.Should().BeTrue();

            result.Errors.Should().BeEquivalentTo(null);            
        }

        [Fact]
        public void GetUserClaims_ShouldReturnError_ReturnFailed()
        {   
            // Act
            var result = _manageToken.GetUserClaims(expiredToken);

            // Assert
            result.EmailAddress.Should().BeEquivalentTo(null);

            result.Success.Should().BeFalse();

            result.Errors.Should().BeEquivalentTo(new List<string>() { "Token Expired" });
        }

        [Fact]
        public async Task VerifyAndGenerateToken_validate_expiry_date()
        {
            // Arrange
            var user = new IdentityUser
            {
                Email = "qasim@abc.com",
                Id = Guid.NewGuid().ToString()
            };

            var response = await _manageToken.GenerateJwtToken(user);

            // Act
            var result = await _manageToken.VerifyAndGenerateToken(response.Token, response.RefreshToken);

            // Assert
            result.Errors.Should().BeEquivalentTo(new List<string>() { "Token has not yet expired" });

            result.Success.Should().BeFalse();
        }

        [Fact]
        public async Task VerifyAndGenerateToken_validate_existence_of_the_token()
        {
            // Arrange
            string refreshToken = Guid.NewGuid().ToString();

            // Act
            var result = await _manageToken.VerifyAndGenerateToken(expiredToken, refreshToken);

            // Assert
            result.Errors.Should().BeEquivalentTo(new List<string>() { "Token does not exist" });

            result.Success.Should().BeFalse();
        }


        [Fact]
        public async Task VerifyAndGenerateToken_validate_used_refreshToken()
        {
            // Arrange
            string refreshToken = Guid.NewGuid().ToString();

            using (var context = _gatewayDbContext)
            {
                var entity = new RefreshToken
                {
                    Id = 24,
                    UserId = Guid.NewGuid().ToString(),
                    AddedDate = DateTime.Now,
                    ExpiryDate = DateTime.Now.AddDays(1),
                    IsRevorked = true,
                    IsUsed = true,
                    JwtId = Guid.NewGuid().ToString(),
                    Token = refreshToken
                };

                context.RefreshTokens.Add(entity);

                await context.SaveChangesAsync();

                // Act
                var result = await _manageToken.VerifyAndGenerateToken(expiredToken, refreshToken);

                // Assert
                result.Errors.Should().BeEquivalentTo(new List<string>() { "Token has been used" });

                result.Success.Should().BeFalse();
            }
        }

        [Fact]
        public async Task VerifyAndGenerateToken_validate_revoked_refreshToken()
        {
            // Arrange
            string refreshToken = Guid.NewGuid().ToString();

            using (var context = _gatewayDbContext)
            {
                var entity = new RefreshToken
                {
                    Id = 25,
                    UserId = Guid.NewGuid().ToString(),
                    AddedDate = DateTime.Now,
                    ExpiryDate = DateTime.Now.AddDays(1),
                    IsRevorked = true,
                    IsUsed = false,
                    JwtId = Guid.NewGuid().ToString(),
                    Token = refreshToken
                };

                context.RefreshTokens.Add(entity);

                await context.SaveChangesAsync();

                // Act
                var result = await _manageToken.VerifyAndGenerateToken(expiredToken, refreshToken);

                // Assert
                result.Errors.Should().BeEquivalentTo(new List<string>() { "Token has been revoked" });

                result.Success.Should().BeFalse();
            }
        }

        [Fact]
        public async Task VerifyAndGenerateToken_validate_jwt_Id_refreshToken()
        {
            // Arrange
            string refreshToken = Guid.NewGuid().ToString();

            using (var context = _gatewayDbContext)
            {
                var entity = new RefreshToken
                {
                    Id = 1,
                    UserId = Guid.NewGuid().ToString(),
                    AddedDate = DateTime.Now,
                    ExpiryDate = DateTime.Now.AddDays(1),
                    IsRevorked = false,
                    IsUsed = false,
                    JwtId = Guid.NewGuid().ToString(),
                    Token = refreshToken
                };

                context.RefreshTokens.Add(entity);

                await context.SaveChangesAsync();

                // Act
                var result = await _manageToken.VerifyAndGenerateToken(expiredToken, refreshToken);

                // Assert
                result.Errors.Should().BeEquivalentTo(new List<string>() { "Token doesn't match" });
            }
        }

        public void Dispose()
        {
            _gatewayDbContext.Dispose();
        }
    }
}
