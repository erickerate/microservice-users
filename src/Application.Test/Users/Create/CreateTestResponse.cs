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
    /// Resposta requisição objeto criado
    /// </summary>
    public class CreateTestResponse : BaseRequestTestResponse
    {
        #region Members 'Meets' :: Meets()

        [Fact(DisplayName = "Deve ser receber um Created quando usuário criado.")]
        public async Task Meets()
        {
            string name = Faker.Name.FullName();
            int age = Faker.RandomNumber.Next(0, 50);
            string emailAddress = Faker.Internet.Email();
            string password = Faker.Name.Last();

            CreatedUserDto createdUserDto = new CreatedUserDto
            {
                Id = Guid.NewGuid(),
                Name = name,
                Age = age,
                EmailAddress = emailAddress,
                Password = password
            };
            this.ServiceMock
                .Setup(m => m.Post(It.IsAny<CreateUserDto>()))
                .ReturnsAsync(createdUserDto)
                ;

            this.UsersController = new UsersController(this.ServiceMock.Object);

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url
                .Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>()))
                .Returns("http://localhost:5139")
                ;
            this.UsersController.Url = url.Object;

            CreateUserDto createUserDto = new CreateUserDto
            {
                Name = name,
                Age = age,
                EmailAddress = emailAddress,
                Password = password
            };

            ActionResult result = await this.UsersController.Post(createUserDto);
            Assert.True(result is CreatedResult);

            CreatedUserDto? resultValue = ((CreatedResult)result).Value as CreatedUserDto;
            Assert.NotNull(resultValue);
            Assert.Equal(createUserDto.Name, resultValue.Name);
            Assert.Equal(createUserDto.Age, resultValue.Age);
            Assert.Equal(createUserDto.EmailAddress, resultValue.EmailAddress);
            Assert.Equal(createUserDto.Password, resultValue.Password);
        }

        #endregion
    }
}
