using Domain.Dtos.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserMicroservice.Test.Users
{
    /// <summary>
    /// Teste serviço usuário
    /// </summary>
    public class UserServiceTest
    {
        #region Constructors

        /// <summary>
        /// Teste serviço usuário
        /// </summary>
        public UserServiceTest()
        {
            for (int index = 0; index < 10; index++)
            {
                UserDto userDto = new UserDto()
                {
                    Id = Guid.NewGuid(),
                    Age = Faker.RandomNumber.Next(0, 80),
                    Name = Faker.Name.FullName(),
                    EmailAddress = Faker.Internet.Email(),
                    Password = Faker.Name.Last()
                };
                UserDtos.Add(userDto);
            }

            UserId = Guid.NewGuid();
            UserName = Faker.Name.FullName();
            UserAge = Faker.RandomNumber.Next(0, 80);
            UserEmailAddress = Faker.Internet.Email();
            UserPassword = Faker.Name.Last();
            ChangedUserName = Faker.Name.FullName();
            ChangedUserEmailAddress = Faker.Internet.Email();

            UserDto = new UserDto
            {
                Id = UserId,
                Name = UserName,
                Age = UserAge,
                EmailAddress = UserEmailAddress,
                Password = UserPassword
            };

            CreateUserDto = new CreateUserDto
            {
                Name = UserName,
                Age = UserAge,
                EmailAddress = UserEmailAddress,
                Password = UserPassword
            };

            CreatedUserDto = new CreatedUserDto
            {
                Id = UserId,
                Name = UserName,
                Age = UserAge,
                EmailAddress = UserEmailAddress,
                Password = UserPassword
            };

            UpdateUserDto = new UpdateUserDto
            {
                Id = UserId,
                Name = ChangedUserName,
                Age = UserAge,
                EmailAddress = ChangedUserEmailAddress,
                Password = UserPassword
            };

            UpdatedUserDto = new UpdatedUserDto
            {
                Id = UserId,
                Name = ChangedUserName,
                Age = UserAge,
                EmailAddress = ChangedUserEmailAddress,
                Password = UserPassword
            };
        }

        #endregion

        #region Members 'Dtos' :: UserDtos, UserDto, CreateUserDto, CreatedUserDto, UpdateUserDto, UpdatedUserDto

        /// <summary>
        /// Coleção de usuários
        /// </summary>
        public virtual List<UserDto> UserDtos { get; set; } = new List<UserDto>();

        /// <summary>
        /// Usuário
        /// </summary>
        public virtual UserDto UserDto { get; set; }

        /// <summary>
        /// Usuário para criar
        /// </summary>
        public virtual CreateUserDto CreateUserDto { get; set; }

        /// <summary>
        /// Usuário criado
        /// </summary>
        public virtual CreatedUserDto CreatedUserDto { get; set; }

        /// <summary>
        /// Usuário para atualizar
        /// </summary>
        public virtual UpdateUserDto UpdateUserDto { get; set; }

        /// <summary>
        /// Usuário atualizado
        /// </summary>
        public virtual UpdatedUserDto UpdatedUserDto { get; set; }

        #endregion

        #region Members 'Static' :: UserId, UserName, UserAge, UserEmailAddress, UserPassword, ChangedUserName, ChangedUserEmailAddress

        /// <summary>
        /// Identificador do usuário
        /// </summary>
        public static Guid UserId { get; set; }

        /// <summary>
        /// Nome do usuário
        /// </summary>
        public static string? UserName { get; set; }

        /// <summary>
        /// Idade
        /// </summary>
        public static int UserAge { get; set; }

        /// <summary>
        /// Endereço de e-mail do usuário
        /// </summary>
        public static string? UserEmailAddress { get; set; }

        /// <summary>
        /// Palavra-passe
        /// </summary>
        public static string? UserPassword { get; set; }

        /// <summary>
        /// Nome do usuário alterado
        /// </summary>
        public static string? ChangedUserName { get; set; }

        /// <summary>
        /// E-mail do usuário alterado
        /// </summary>
        public static string? ChangedUserEmailAddress { get; set; }

        #endregion
    }
}
