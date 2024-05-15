using Domain.Context;
using Domain.Dtos.Users;
using Domain.Entities.User;
using Domain.Interfaces;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Users
{
    /// <summary>
    /// Repositório do usuário
    /// </summary>
    public class UserRepository : Repository<User>, IUserRepository
    {
        #region Constructors

        /// <summary>
        /// Repositório do usuário
        /// </summary>
        /// <param name="context"></param>
        public UserRepository(JuntoSegurosContext context) 
            : base(context)
        {
        }

        #endregion

        #region Members 'Utils' :: FindByEmailAddress()

        /// <summary>
        /// Encontrar usuário através do endereço de email
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<User?> FindByEmailAddress(string emailAddress)
        {
            try
            {
                return await this.DataSet.FirstOrDefaultAsync(w => w.EmailAddress == emailAddress);
            }
            catch(Exception exception)
            {
                throw new Exception("Fail in FindByEmailAddress(): ", exception);
            }
        }

        #endregion
    }
}
