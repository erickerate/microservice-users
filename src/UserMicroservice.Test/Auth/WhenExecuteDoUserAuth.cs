using Domain.Dtos.Users;
using Domain.Interfaces;
using Domain.Interfaces.Users;
using Moq;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserMicroservice.Test.Auth
{
    /// <summary>
    /// Quando executar: DoUserAuth()
    /// </summary>
    public class WhenExecuteDoUserAuth
    {
        #region Members 'Mock' :: serviceMock

        private Mock<IUserAuthService>? serviceMock;

        #endregion

        #region Members 'Service' :: service, Meets()

        private IUserAuthService? service;

        [Fact(DisplayName = "Deve executar o Método DoUserAuth.")]
        public async Task Meets()
        {
            string emailAddress = Faker.Internet.Email();
            object response = new
            {
                authenticated = true,
                createdAt = DateTime.UtcNow,
                expirationAt = DateTime.UtcNow.AddHours(8),
                accessToken = Guid.NewGuid(),
                emailAddress = emailAddress,
                message = "User successfully authenticated"
            };

            UserAuthDto userAuthDto = new UserAuthDto
            {
                EmailAddress = emailAddress
            };

            this.serviceMock = new Mock<IUserAuthService>();
            this.serviceMock
                .Setup(m => m.DoUserAuth(userAuthDto.EmailAddress))
                .ReturnsAsync(response)
                ;
            this.service = this.serviceMock.Object;

            object? result = await this.service.DoUserAuth(userAuthDto.EmailAddress);
            Assert.NotNull(result);
        }

        #endregion
    }
}
