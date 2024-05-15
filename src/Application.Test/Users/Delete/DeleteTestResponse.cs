using Application.Controllers;
using Domain.Dtos.Users;
using Domain.Interfaces.Users;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Test.Users.Delete
{
    /// <summary>
    /// Resposta requisição bem sucedida
    /// </summary>
    public class DeleteTestResponse : BaseRequestTestResponse
    {
        #region Members 'Meets' :: Meets()

        [Fact(DisplayName = "Deve apagar um registro.")]
        public async Task Meets()
        {
            this.ServiceMock
                .Setup(m => m.Delete(It.IsAny<Guid>()))
                .ReturnsAsync(true)
                ;

            this.UsersController = new UsersController(this.ServiceMock.Object);

            ActionResult? result = await this.UsersController.Delete(Guid.NewGuid());
            bool? resultValue = ((OkObjectResult)result).Value as bool?;
            Assert.NotNull(resultValue);
            Assert.True(resultValue);
        }

        #endregion
    }
}
