using Domain.Dtos.Users;
using Domain.Interfaces;
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
    /// Quando executar: GetAll()
    /// </summary>
    public class WhenExecuteGetAll : UserServiceTest
    {
        #region Members 'Mock' :: serviceMock

        private Mock<IUserService>? serviceMock;

        #endregion

        #region Members 'Service' :: service, Meets()

        private IUserService? service;

        [Fact(DisplayName = "Deve executar o Método GetAll.")]
        public async Task Meets()
        {
            // Cria simulação
            serviceMock = new Mock<IUserService>();
            serviceMock
                .Setup(m => m.GetAll())
                .ReturnsAsync(UserDtos)
                ;
            service = serviceMock.Object;
            IEnumerable<UserDto> userDtos = await service.GetAll();
            Assert.NotNull(userDtos);
            Assert.True(userDtos.Count() == 10);

            // Cria simulação
            IEnumerable<UserDto> emptyUserDtos = new List<UserDto>();
            serviceMock = new Mock<IUserService>();
            serviceMock
                .Setup(m => m.GetAll())
                .ReturnsAsync(emptyUserDtos)
                ;
            service = serviceMock.Object;
            userDtos = await service.GetAll();
            Assert.Empty(userDtos);
            Assert.True(userDtos.Count() == 0);
        }

        #endregion
    }
}
