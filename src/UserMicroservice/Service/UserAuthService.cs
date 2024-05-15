using Domain.Context;
using Domain.Entities.User;
using Domain.Interfaces.Users;
using Domain.Repositories;
using Domain.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace UserMicroservice.Service
{
    /// <summary>
    /// Serviço de autenticação de usuário
    /// </summary>
    public class UserAuthService : IUserAuthService
    {
        #region Constructors

        /// <summary>
        /// Serviço de autenticação de usuário
        /// </summary>
        /// <param name=""></param>
        public UserAuthService(
            IUserRepository repository, 
            SigningConfigurations signingConfigurations, 
            TokenConfigurations tokenConfigurations
        )
        {
            this.Repository = repository;
            this.signingConfigurations = signingConfigurations;
            this.tokenConfigurations = tokenConfigurations;
        }

        #endregion

        #region Members 'Repository' :: Repository

        /// <summary>
        /// Repositório
        /// </summary>
        protected readonly IUserRepository Repository;

        #endregion

        #region Members 'Security' :: signingConfigurations, tokenConfigurations

        /// <summary>
        /// Configurações de assinatura
        /// </summary>
        private SigningConfigurations signingConfigurations;

        /// <summary>
        /// Configurações do token
        /// </summary>
        private TokenConfigurations tokenConfigurations;

        #endregion

        #region Members 'Auth' :: DoUserAuth()

        /// <summary>
        /// Faz autenticação do usuário
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<object?> DoUserAuth(string emailAddress)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(emailAddress)) return null;

                #region 1. Usuário não autenticado

                User? registeredUser = null;
                registeredUser = await this.Repository.FindByEmailAddress(emailAddress);
                if (registeredUser == null)
                {
                    return new
                    {
                        authenticated = false,
                        message = "Failed to authenticate user"
                    };
                }

                #endregion

                #region 2. Usuário autenticado

                IEnumerable<Claim> claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.UniqueName, emailAddress),
                };
                GenericIdentity genericIdentity = new GenericIdentity(emailAddress);
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(genericIdentity, claims);
                DateTime createdAt = DateTime.UtcNow;
                DateTime expirationAt = createdAt + TimeSpan.FromSeconds(this.tokenConfigurations.Seconds);
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                string token = this.createToken(claimsIdentity, createdAt, expirationAt, handler);
                return new
                {
                    authenticated = true,
                    createdAt = createdAt.ToString("yyyy-MM-dd HH:mm:ss"),
                    expirationAt = expirationAt.ToString("yyyy-MM-dd HH:mm:ss"),
                    accessToken = token,
                    emailAddress = emailAddress,
                    message = "User successfully authenticated"
                };

                #endregion
            }
            catch (Exception exception)
            {
                throw new Exception("Fail in DoUserAuth(): ", exception);
            }
        }

        /// <summary>
        /// Criar token
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private string createToken(ClaimsIdentity claimsIdentity, DateTime createdAt, DateTime expirationAt, JwtSecurityTokenHandler handler)
        {
            try
            {
                SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
                {
                    Issuer = this.tokenConfigurations.Issuer,
                    Audience = this.tokenConfigurations.Audience,
                    SigningCredentials = this.signingConfigurations.SigningCredentials,
                    Subject = claimsIdentity,
                    NotBefore = createdAt,
                    Expires = expirationAt
                };
                SecurityToken securityToken = handler.CreateToken(descriptor);
                string token = handler.WriteToken(securityToken);
                return token;
            }
            catch (Exception exception)
            {
                throw new Exception("Fail in createToken(): ", exception);
            }
        }

        #endregion
    }
}
