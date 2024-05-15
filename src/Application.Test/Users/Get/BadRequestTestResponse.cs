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

namespace Application.Test.Users.Get
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
            string name = Faker.Name.FullName();
            int age = Faker.RandomNumber.Next(0, 50);
            string emailAddress = Faker.Internet.Email();
            string password = Faker.Name.Last();

            UserDto userDto = new UserDto
            {
                Id = Guid.NewGuid(),
                Age = age,
                Name = name,
                EmailAddress = emailAddress,
                Password = password
            };

            this.ServiceMock
                .Setup(m => m.Get(It.IsAny<Guid>()))
                .ReturnsAsync(userDto);

            this.UsersController = new UsersController(this.ServiceMock.Object);
            this.UsersController.ModelState.AddModelError("Id", "Formato Inválido");

            ActionResult result = await this.UsersController.Get(Guid.NewGuid());
            Assert.True(result is BadRequestObjectResult);
        }

        #endregion
    }
}
