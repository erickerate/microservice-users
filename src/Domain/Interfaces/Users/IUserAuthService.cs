using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Users
{
    /// <summary>
    /// Serviço de autenticação de usuário
    /// </summary>
    public interface IUserAuthService
    {
        /// <summary>
        /// Faz autenticação do usuário
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<object?> DoUserAuth(string emailAddress);
    }
}
