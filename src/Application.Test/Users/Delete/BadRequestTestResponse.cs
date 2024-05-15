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
    /// Resposta requisição mal-sucedida
    /// </summary>
    public class BadRequestTestResponse : BaseRequestTestResponse
    {
        #region Members 'Meets' :: Meets()

        [Fact(DisplayName = "Deve retornar BadRequest quando faltar ao menos um campo estiver com formato inválido.")]
        public async Task Meets()
        {
            this.ServiceMock
                .Setup(m => m.Delete(It.IsAny<Guid>()))
                .ReturnsAsync(false)
                ;

            this.UsersController = new UsersController(this.ServiceMock.Object);
            this.UsersController.ModelState.AddModelError("Id", "Formato Inválido");

            ActionResult? result = await this.UsersController.Delete(default(Guid));
            Assert.True(result is BadRequestObjectResult);
            Assert.False(this.UsersController.ModelState.IsValid);
        }

        #endregion
    }
}
