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
    /// Resposta requisição bem-sucedida
    /// </summary>
    public class UpdateTestResponse : BaseRequestTestResponse
    {
        #region Members 'Meets' :: Meets()

        [Fact(DisplayName = "Deve atualizar um registro.")]
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
            Assert.True(result is OkObjectResult);

            UpdatedUserDto? resultValue = ((OkObjectResult)result).Value as UpdatedUserDto;
            Assert.NotNull(resultValue);
            Assert.Equal(updateUserDto.Name, resultValue.Name);
            Assert.Equal(updateUserDto.Age, resultValue.Age);
            Assert.Equal(updateUserDto.EmailAddress, resultValue.EmailAddress);
            Assert.Equal(updateUserDto.Password, resultValue.Password);
        }

        [Fact(DisplayName = "Deve alterar a senha")]
        public async Task ChangePassword()
        {
            string name = Faker.Name.FullName();
            int age = Faker.RandomNumber.Next(0, 50);
            string emailAddress = Faker.Internet.Email();
            string password = "10";

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

            string newPassword = password;
            ChangeUserPasswordDto changeUserPasswordDto = new ChangeUserPasswordDto
            {
                Id = Guid.NewGuid(),
                CurrentPassword = password,
                NewPassword = newPassword
            };

            ActionResult result = await this.UsersController.ChangePassword(changeUserPasswordDto);
            UpdatedUserDto? resultValue = ((OkObjectResult)result).Value as UpdatedUserDto;
            Assert.True(result is OkObjectResult);
            Assert.NotNull(resultValue);
            Assert.Equal(newPassword, resultValue.Password);
        }

        #endregion
    }
}
