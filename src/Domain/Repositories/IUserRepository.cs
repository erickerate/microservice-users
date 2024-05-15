using Domain.Dtos.Users;
using Domain.Entities.User;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    /// <summary>
    /// Repositório do usuário
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// Encontrar usuário através do endereço de email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<User?> FindByEmailAddress(string email);
    }
}
