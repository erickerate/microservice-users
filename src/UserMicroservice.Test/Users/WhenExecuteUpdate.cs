﻿using Domain.Dtos.Users;
using Domain.Interfaces;
using Domain.Interfaces.Users;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserMicroservice.Test.Users
{
    /// <summary>
    /// Quando executar: Update()
    /// </summary>
    public class WhenExecuteUpdate : UserServiceTest
    {
        #region Members 'Mock' :: serviceMock

        private Mock<IUserService>? serviceMock;

        #endregion

        #region Members 'Service' :: service, Meets()

        private IUserService? service;

        [Fact(DisplayName = "Deve executar o Método Update.")]
        public async Task Meets()
        {
            // Cria simulação
            serviceMock = new Mock<IUserService>();
            serviceMock
                .Setup(m => m.Post(CreateUserDto))
                .ReturnsAsync(CreatedUserDto)
                ;
            service = serviceMock.Object;
            CreatedUserDto createdUserDto = await service.Post(CreateUserDto);
            Assert.NotNull(createdUserDto);
            Assert.Equal(UserName, createdUserDto.Name);
            Assert.Equal(UserEmailAddress, createdUserDto.EmailAddress);

            // Cria simulação
            serviceMock = new Mock<IUserService>();
            serviceMock
                .Setup(m => m.Put(UpdateUserDto))
                .ReturnsAsync(UpdatedUserDto)
                ;
            service = serviceMock.Object;
            UpdatedUserDto? updatedUserDto = await service.Put(UpdateUserDto);
            Assert.NotNull(updatedUserDto);
            Assert.Equal(ChangedUserName, updatedUserDto.Name);
            Assert.Equal(ChangedUserEmailAddress, updatedUserDto.EmailAddress);
        }

        #endregion
    }
}
