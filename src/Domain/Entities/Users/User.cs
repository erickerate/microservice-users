using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.User
{
    /// <summary>
    /// Usuário
    /// </summary>
    [Table("Users")]
    public class User : EntityBase
    {
        #region Members 'Header' :: Name, Age, EmailAddress, Password

        /// <summary>
        /// Nome
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Idade
        /// </summary>
        public required int Age { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public required string EmailAddress { get; set; }

        /// <summary>
        /// Palavra-passe
        /// </summary>
        public required string Password { get; set; }

        #endregion
    }
}
