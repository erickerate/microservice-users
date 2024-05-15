using System;
using System.Linq;
using System.Threading.Tasks;
using Data.Repository.Users;
using Data.Test;
using Domain.Context;
using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Data.Test
{
    /// <summary>
    /// Teste repositório usuário
    /// </summary>
    public class UserRepositoryTest : IClassFixture<DatabaseProvider>
    {
        #region Constructors

        /// <summary>
        /// este repositório usuário
        /// </summary>
        /// <param name="databaseProvider"></param>
        public UserRepositoryTest(DatabaseProvider databaseProvider)
        {
            this.serviceProvider = databaseProvider.ServiceProvider;
        }

        #endregion

        #region Members 'Dependencies' ::serviceProvider

        /// <summary>
        /// Provedor
        /// </summary>
        private ServiceProvider serviceProvider;

        #endregion

        #region Members 'Test CRUD' :: MustPerformCrudOperations()

        [Fact(DisplayName = "Deve realizar operações CRUD")]
        [Trait("CRUD", "User")]
        public async Task MustPerformCrudOperations()
        {
            try
            {
                using (JuntoSegurosContext context = this.serviceProvider.GetService<JuntoSegurosContext>()!)
                {
                    #region 1. Repositório

                    UserRepository userRepository = new UserRepository(context);

                    #endregion

                    #region 2. Create

                    User toCreateUser = new User
                    {
                        Name = Faker.Name.FullName(),
                        Age = Faker.RandomNumber.Next(0, 50),
                        EmailAddress = Faker.Internet.Email(),
                        Password = Faker.Name.Last()
                    };

                    User createdUser = await userRepository.InsertAsync(toCreateUser);

                    Assert.NotNull(createdUser);
                    Assert.True(createdUser.Id != Guid.Empty);
                    Assert.Equal(toCreateUser.Name, createdUser.Name);
                    Assert.Equal(toCreateUser.Age, createdUser.Age);
                    Assert.Equal(toCreateUser.EmailAddress, createdUser.EmailAddress);
                    Assert.Equal(toCreateUser.Password, createdUser.Password);

                    User toCreateUser2 = new User
                    {
                        Name = createdUser.Name,
                        Age = createdUser.Age,
                        EmailAddress = createdUser.EmailAddress,
                        Password = createdUser.Password
                    };

                    try
                    {
                        User createdUser2 = await userRepository.InsertAsync(toCreateUser2);
                    }
                    catch (Exception exception)
                    {
                        Assert.True(exception is DbUpdateException);
                    }

                    #endregion

                    #region 3. Read

                    // Todos
                    IEnumerable<User> existentUsers = await userRepository.SelectAsync();
                    Assert.NotNull(existentUsers);
                    Assert.True(existentUsers.Count() > 0);

                    // Pelo identificador
                    User? existentUser = await userRepository.SelectAsync(createdUser.Id);
                    Assert.NotNull(existentUser);
                    Assert.True(existentUser.Id != Guid.Empty);

                    #endregion

                    #region 4. Update

                    existentUser!.Name = Faker.Name.FullName();
                    existentUser!.Age = Faker.RandomNumber.Next(0, 20);
                    existentUser!.EmailAddress = Faker.Internet.Email();
                    existentUser!.Password = Faker.Name.Last();

                    User? updatedUser = await userRepository.UpdateAsync(existentUser);
                    Assert.NotNull(updatedUser);
                    Assert.Equal(existentUser.Name, updatedUser.Name);
                    Assert.Equal(existentUser.Age, updatedUser.Age);
                    Assert.Equal(existentUser.EmailAddress, updatedUser.EmailAddress);
                    Assert.Equal(existentUser.Password, updatedUser.Password);

                    #endregion

                    #region 5. Delete

                    bool deleted = await userRepository.DeleteAsync(existentUser.Id);
                    Assert.True(deleted);
                    User? deletedUser = await userRepository.SelectAsync(existentUser.Id);
                    bool userNotExists = deletedUser == null;
                    Assert.True(userNotExists);

                    #endregion
                }
            }
            catch (Exception exception) 
            {
                throw new Exception("Fail in MustPerformCrudOperations(): ", exception);
            }
        }

        [Fact(DisplayName = "Deve obter usuário")]
        [Trait("CRUD", "User")]
        public async Task MustGetUser()
        {
            using (JuntoSegurosContext context = this.serviceProvider.GetService<JuntoSegurosContext>()!)
            {
                UserRepository userRepository = new UserRepository(context);

                IEnumerable<User> existentUsers = await userRepository.SelectAsync();
                Assert.NotNull(existentUsers);
            }
        }

        [Fact(DisplayName = "Deve atualizar usuário")]
        [Trait("CRUD", "User")]
        public async Task MustUpdateUser()
        {
            using (JuntoSegurosContext context = this.serviceProvider.GetService<JuntoSegurosContext>()!)
            {
                UserRepository userRepository = new UserRepository(context);

                IEnumerable<User> existentUsers = await userRepository.SelectAsync();

                User? existentUser = existentUsers.FirstOrDefault();
                if (existentUser != null) 
                {
                    existentUser.Name = existentUser.Name + Guid.NewGuid().ToString().Substring(0, 5);
                    User? updatedUser = await userRepository.UpdateAsync(existentUser);
                    Assert.NotNull(updatedUser);
                    Assert.Equal(existentUser.Name, updatedUser.Name);
                }
            }
        }

        [Fact(DisplayName = "Deve apagar usuário")]
        [Trait("CRUD", "User")]
        public async Task MustDeleteUser()
        {
            using (JuntoSegurosContext context = this.serviceProvider.GetService<JuntoSegurosContext>()!)
            {
                UserRepository userRepository = new UserRepository(context);

                IEnumerable<User> existentUsers = await userRepository.SelectAsync();

                User? existentUser = existentUsers.FirstOrDefault();
                if (existentUser != null)
                {
                    bool success = await userRepository.DeleteAsync(existentUser.Id);
                    Assert.True(success);
                }
            }
        }

        #endregion
    }
}
