using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.Users
{
    /// <summary>
    /// Objeto para alterar palavra-passe
    /// </summary>
    public class ChangeUserPasswordDto
    {
        #region Members 'Header' :: Id, CurrentPassword, NewPassword

        /// <summary>
        /// Identificador
        /// </summary>
        public required Guid Id { get; set; }

        /// <summary>
        /// Palavra-passe atual
        /// </summary>
        public required string CurrentPassword { get; set; }

        /// <summary>
        /// Nova palavra-passe
        /// </summary>
        public required string NewPassword { get; set; }

        #endregion
    }
}
