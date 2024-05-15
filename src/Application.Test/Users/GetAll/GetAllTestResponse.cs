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

namespace Application.Test.Users.GetAll
{
    /// <summary>
    /// Resposta requisição bem-sucedida
    /// </summary>
    public class GetAllTestResponse : BaseRequestTestResponse
    {
        #region Members 'Meets' :: Meets()

        [Fact(DisplayName = "Deve obter a coleção de registros.")]
        public async Task Meets()
        {
            this.ServiceMock
               .Setup(m => m.GetAll())
               .ReturnsAsync(
                   new List<UserDto>
                   {
                        new UserDto
                        {
                            Id = Guid.NewGuid(),
                            Age = Faker.RandomNumber.Next(0, 50),
                            Name = Faker.Name.FullName(),
                            EmailAddress =  Faker.Internet.Email(),
                            Password = Faker.Name.Last()
                        },
                        new UserDto
                        {
                            Id = Guid.NewGuid(),
                            Age = Faker.RandomNumber.Next(0, 50),
                            Name = Faker.Name.FullName(),
                            EmailAddress =  Faker.Internet.Email(),
                            Password = Faker.Name.Last()
                        }
                   }
               );

            this.UsersController = new UsersController(this.ServiceMock.Object);

            ActionResult result = await this.UsersController.GetAll();
            Assert.True(result is OkObjectResult);

            IEnumerable<UserDto>? userDtos = ((OkObjectResult)result).Value as IEnumerable<UserDto>;
            Assert.NotNull(userDtos);
            Assert.True(userDtos.Count() == 2);
        }

        #endregion
    }
}
