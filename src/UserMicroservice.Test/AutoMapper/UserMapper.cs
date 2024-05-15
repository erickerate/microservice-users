using Domain.Dtos.Users;
using Domain.Entities.User;
using Domain.Interfaces.Users;
using Domain.Models.Users;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserMicroservice.Test.Autothis.Mapper
{
    /// <summary>
    /// Mapeador de usuário
    /// </summary>
    public class UserMapper : BaseTestService
    {
        #region Members 'Meets' :: Meets()

        [Fact(DisplayName = "Deve mapear os modelos de usuário.")]
        public void Meets()
        {
            #region 1. Prepara

            UserModel userModel = new UserModel
            {
                Id = Guid.NewGuid(),
                Name = Faker.Name.FullName(),
                Age = Faker.RandomNumber.Next(0, 50),
                EmailAddress = Faker.Internet.Email(),
                Password = Faker.Name.Last()
            };

            List<User> users = new List<User>();
            for (int index = 0; index < 5; index++)
            {
                User item = new User
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Age = Faker.RandomNumber.Next(0, 50),
                    EmailAddress = Faker.Internet.Email(),
                    Password = Faker.Name.Last()
                };
                users.Add(item);
            }

            #endregion

            #region 2. Model => Entity

            User user = this.Mapper.Map<User>(userModel);
            Assert.Equal(user.Id, userModel.Id);
            Assert.Equal(user.Name, userModel.Name);
            Assert.Equal(user.Age, userModel.Age);
            Assert.Equal(user.EmailAddress, userModel.EmailAddress);
            Assert.Equal(user.Password, userModel.Password);

            #endregion

            #region 3. Entity => Dto

            UserDto userDto = this.Mapper.Map<UserDto>(user);
            Assert.Equal(userDto.Id, user.Id);
            Assert.Equal(userDto.Name, user.Name);
            Assert.Equal(userDto.Age, user.Age);
            Assert.Equal(userDto.EmailAddress, user.EmailAddress);
            Assert.Equal(userDto.Password, user.Password);

            List<UserDto> userDtos = this.Mapper.Map<List<UserDto>>(users);
            Assert.True(userDtos.Count() == users.Count());
            for (int index = 0; index < userDtos.Count(); index++)
            {
                Assert.Equal(userDtos[index].Id, users[index].Id);
                Assert.Equal(userDtos[index].Age, users[index].Age);
                Assert.Equal(userDtos[index].Name, users[index].Name);
                Assert.Equal(userDtos[index].EmailAddress, users[index].EmailAddress);
                Assert.Equal(userDtos[index].Password, users[index].Password);
            }

            CreatedUserDto createdUserDto = this.Mapper.Map<CreatedUserDto>(user);
            Assert.Equal(createdUserDto.Id, user.Id);
            Assert.Equal(createdUserDto.Age, user.Age);
            Assert.Equal(createdUserDto.Name, user.Name);
            Assert.Equal(createdUserDto.EmailAddress, user.EmailAddress);
            Assert.Equal(createdUserDto.Password, user.Password);

            UpdatedUserDto updatedUserDto = this.Mapper.Map<UpdatedUserDto>(user);
            Assert.Equal(updatedUserDto.Id, user.Id);
            Assert.Equal(updatedUserDto.Age, user.Age);
            Assert.Equal(updatedUserDto.Name, user.Name);
            Assert.Equal(updatedUserDto.EmailAddress, user.EmailAddress);
            Assert.Equal(updatedUserDto.Password, user.Password);

            #endregion

            #region Dto => Model

            userModel = this.Mapper.Map<UserModel>(userDto);
            Assert.Equal(userModel.Id, userDto.Id);
            Assert.Equal(userModel.Age, userDto.Age);
            Assert.Equal(userModel.Name, userDto.Name);
            Assert.Equal(userModel.EmailAddress, userDto.EmailAddress);
            Assert.Equal(userModel.Password, userDto.Password);

            CreateUserDto createUserDto = this.Mapper.Map<CreateUserDto>(userModel);
            Assert.Equal(createUserDto.Name, userModel.Name);
            Assert.Equal(createUserDto.Age, userModel.Age);
            Assert.Equal(createUserDto.EmailAddress, userModel.EmailAddress);
            Assert.Equal(createUserDto.Password, userModel.Password);

            UpdateUserDto updateUserDto = this.Mapper.Map<UpdateUserDto>(userModel);
            Assert.Equal(updateUserDto.Id, userModel.Id);
            Assert.Equal(updateUserDto.Name, userModel.Name);
            Assert.Equal(updateUserDto.Age, userModel.Age);
            Assert.Equal(updateUserDto.EmailAddress, userModel.EmailAddress);
            Assert.Equal(updateUserDto.Password, userModel.Password);

            #endregion
        }

        #endregion
    }
}
