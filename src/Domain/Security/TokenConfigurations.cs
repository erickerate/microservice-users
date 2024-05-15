using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Security
{
    /// <summary>
    /// Coleção de configurações do token
    /// </summary>
    public class TokenConfigurations
    {
        #region Members 'Header' :: Audience, Issuer, Seconds

        /// <summary>
        /// Público
        /// </summary>
        public string? Audience { get; set; }

        /// <summary>
        /// Emissor
        /// </summary>
        public string? Issuer { get; set; }

        /// <summary>
        /// Segundos
        /// </summary>
        public int Seconds { get; set; }

        #endregion
    }
}
