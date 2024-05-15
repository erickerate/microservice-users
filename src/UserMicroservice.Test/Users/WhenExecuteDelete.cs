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
    /// Quando executar: Delete()
    /// </summary>
    public class WhenExecuteDelete : UserServiceTest
    {
        #region Members 'Mock' :: serviceMock

        private Mock<IUserService>? serviceMock;

        #endregion

        #region Members 'Service' :: service, Meets()

        private IUserService? service;

        [Fact(DisplayName = "Deve executar o Método Delete.")]
        public async Task Meets()
        {
            // Cria simulação
            serviceMock = new Mock<IUserService>();
            serviceMock
                .Setup(m => m.Delete(UserId))
                .ReturnsAsync(true)
                ;
            service = serviceMock.Object;
            bool deleted = await service.Delete(UserId);
            Assert.True(deleted);

            // Cria simulação
            serviceMock = new Mock<IUserService>();
            serviceMock
                .Setup(m => m.Delete(It.IsAny<Guid>()))
                .ReturnsAsync(false)
                ;
            service = serviceMock.Object;
            deleted = await service.Delete(Guid.NewGuid());
            Assert.False(deleted);
        }

        #endregion
    }
}
