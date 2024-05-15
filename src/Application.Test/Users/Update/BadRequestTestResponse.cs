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

namespace Application.Test.Users.Update
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
            string name = Faker.Name.FullName();
            int age = Faker.RandomNumber.Next(0, 50);
            string emailAddress = Faker.Internet.Email();
            string password = Faker.Name.Last();

            UpdatedUserDto updatedUserDto = new UpdatedUserDto
            {
                Id = Guid.NewGuid(),
                Age = age,
                Name = name,
                EmailAddress = emailAddress,
                Password = password
            };

            this.ServiceMock
                .Setup(m => m.Put(It.IsAny<UpdateUserDto>()))
                .ReturnsAsync(updatedUserDto);

            this.UsersController = new UsersController(this.ServiceMock.Object);
            this.UsersController.ModelState.AddModelError("Email", "É um campo obrigatorio");

            Guid id = Guid.NewGuid();
            UpdateUserDto updateUserDto = new UpdateUserDto
            {
                Id = id,
                Age = age,
                Name = name,
                EmailAddress = emailAddress,
                Password = password
            };

            ActionResult result = await this.UsersController.Put(id, updateUserDto);
            Assert.True(result is BadRequestObjectResult);
            Assert.False(this.UsersController.ModelState.IsValid);
        }

        [Fact(DisplayName = "Deve retornar BadRequest quando faltar ao menos um único campo obrigatório.")]
        public async Task ChangePasswordOnMissingField()
        {
            string name = Faker.Name.FullName();
            int age = Faker.RandomNumber.Next(0, 50);
            string emailAddress = Faker.Internet.Email();
            string password = Faker.Name.Last();

            UpdatedUserDto updatedUserDto = new UpdatedUserDto
            {
                Id = Guid.NewGuid(),
                Age = age,
                Name = name,
                EmailAddress = emailAddress,
                Password = password
            };

            this.ServiceMock
                .Setup(m => m.ChangePassword(It.IsAny<ChangeUserPasswordDto>()))
                .ReturnsAsync(updatedUserDto);

            this.UsersController = new UsersController(this.ServiceMock.Object);
            this.UsersController.ModelState.AddModelError("Password", "É um campo obrigatorio");

            ChangeUserPasswordDto changeUserPasswordDto = new ChangeUserPasswordDto
            {
                Id = Guid.NewGuid(),
                CurrentPassword = password,
                NewPassword = "10"
            };

            ActionResult result = await this.UsersController.ChangePassword(changeUserPasswordDto);
            Assert.True(result is BadRequestObjectResult);
            Assert.False(this.UsersController.ModelState.IsValid);
        }

        [Fact(DisplayName = "Deve retornar BadRequest quando a confirmação de senha atual estiver incorreta.")]
        public async Task ChangePasswordOnIncorrectPassword()
        {
            string name = Faker.Name.FullName();
            int age = Faker.RandomNumber.Next(0, 50);
            string emailAddress = Faker.Internet.Email();
            string password = Faker.Name.Last();

            UpdatedUserDto updatedUserDto = new UpdatedUserDto
            {
                Id = Guid.NewGuid(),
                Age = age,
                Name = name,
                EmailAddress = emailAddress,
                Password = password
            };

            this.ServiceMock
                .Setup(m => m.ChangePassword(It.IsAny<ChangeUserPasswordDto>()))
                .ReturnsAsync((UpdatedUserDto?)null);

            this.UsersController = new UsersController(this.ServiceMock.Object);

            ChangeUserPasswordDto changeUserPasswordDto = new ChangeUserPasswordDto
            {
                Id = Guid.NewGuid(),
                CurrentPassword = password + "p",
                NewPassword = "10"
            };

            ActionResult result = await this.UsersController.ChangePassword(changeUserPasswordDto);
            Assert.True(result is BadRequestObjectResult);
        }

        #endregion
    }
}
