using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Security
{
    /// <summary>
    /// Coleção de configurações de assinatura
    /// </summary>
    public class SigningConfigurations
    {
        #region Constructors

        /// <summary>
        /// Coleção de configurações de assinatura
        /// </summary>
        public SigningConfigurations()
        {
            using (RSACryptoServiceProvider provider = new RSACryptoServiceProvider(2048))
            {
                this.SecurityKey = new RsaSecurityKey(provider.ExportParameters(true));
            }
            this.SigningCredentials = new SigningCredentials(this.SecurityKey, SecurityAlgorithms.RsaSha256Signature);
        }

        #endregion

        #region Members 'Header' :: SecurityKey, SigningCredentials

        /// <summary>
        /// Chave de segurança
        /// </summary>
        public SecurityKey SecurityKey { get; set; }

        /// <summary>
        /// Credenciais
        /// </summary>
        public SigningCredentials SigningCredentials { get; set; }

        #endregion
    }
}
