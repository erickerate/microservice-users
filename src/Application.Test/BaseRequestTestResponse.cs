using Application.Controllers;
using Domain.Interfaces.Users;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Test
{
    /// <summary>
    /// Resposta base requisição
    /// </summary>
    public abstract class BaseRequestTestResponse
    {
        /// <summary>
        /// Controlador usuário
        /// </summary>
        public required UsersController UsersController { get; set; }

        /// <summary>
        /// Simulador
        /// </summary>
        public Mock<IUserService> ServiceMock { get; set; } = new Mock<IUserService>();

    }
}
