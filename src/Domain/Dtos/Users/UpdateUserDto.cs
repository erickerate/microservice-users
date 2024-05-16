using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.Users
{
    /// <summary>
    /// Objeto para atualizar usuário
    /// </summary>
    public class UpdateUserDto
    {
        #region Members 'Header' :: Id, Name, Age, EmailAddress, Password

        /// <summary>
        /// Identificador
        /// </summary>
        public required Guid Id { get; set; }

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
        [Required(ErrorMessage = "E-mail é um campo obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido")]
        [StringLength(100, ErrorMessage = "E-mail deve conter no máximo {1} caracteres")] 
        public required string EmailAddress { get; set; }

        /// <summary>
        /// Palavra-passe
        /// </summary>
        public required string Password { get; set; }

        #endregion
    }
}
