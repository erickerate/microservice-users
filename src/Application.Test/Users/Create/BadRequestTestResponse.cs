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

namespace Application.Test.Users.Create
{
    /// <summary>
    /// Resposta requisição mal-sucedida
    /// </summary>
    public class BadRequestTestResponse : BaseRequestTestResponse
    {
        #region Members 'Meets' :: Meets()

        [Fact(DisplayName = "Deve retornar BadRequest quando faltar ao menos um único campo obrigatório.")]
        public async Task Meets()
        {
            string nome = Faker.Name.FullName();
            int age = Faker.RandomNumber.Next(0, 50);
            string emailAddress = Faker.Internet.Email();
            string password = Faker.Name.Last();

            CreatedUserDto createdUserDto = new CreatedUserDto
            {
                Id = Guid.NewGuid(),
                Name = nome,
                Age = age,
                EmailAddress = emailAddress,
                Password = password
            };
            this.ServiceMock
                .Setup(m => m.Post(It.IsAny<CreateUserDto>()))
                .ReturnsAsync(createdUserDto)
                ;

            this.UsersController = new UsersController(this.ServiceMock.Object);
            this.UsersController.ModelState.AddModelError("Name", "É um Campo Obrigatório");

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url
                .Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>()))
                .Returns("http://localhost:5139")
                ;
            this.UsersController.Url = url.Object;

            CreateUserDto createUserDto = new CreateUserDto
            {
                Name = nome,
                Age = age,
                EmailAddress = emailAddress,
                Password = password
            };

            ActionResult result = await this.UsersController.Post(createUserDto);
            Assert.True(result is BadRequestObjectResult);
        }

        #endregion
    }
}
