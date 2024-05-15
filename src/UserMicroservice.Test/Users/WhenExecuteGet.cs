using Domain.Dtos.Users;
using Domain.Interfaces.Users;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserMicroservice.Test.Users
{
    /// <summary>
    /// Quando executar: Get()
    /// </summary>
    public class WhenExecuteGet : UserServiceTest
    {
        #region Members 'Mock' :: serviceMock

        private Mock<IUserService>? serviceMock;

        #endregion

        #region Members 'Service' :: service, Meets()

        private IUserService? service;

        [Fact(DisplayName = "Deve executar o Método Get.")]
        public async Task Meets()
        {
            // Cria simulação
            serviceMock = new Mock<IUserService>();
            serviceMock
                .Setup(s => s.Get(UserId))
                .ReturnsAsync(UserDto)
                ;
            service = serviceMock.Object;
            UserDto? userDto = await service.Get(UserId);
            Assert.NotNull(userDto);
            Assert.True(userDto.Id == UserId);
            Assert.Equal(UserName, userDto.Name);

            // Cria simulação
            serviceMock = new Mock<IUserService>();
            serviceMock
                .Setup(m => m.Get(It.IsAny<Guid>()))
                .ReturnsAsync((UserDto?)null)
                ;
            service = serviceMock.Object;
            userDto = await service.Get(UserId);
            Assert.Null(userDto);
        }

        #endregion

    }
}
