using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.Users
{
    /// <summary>
    /// Objeto para autenticação de usuário
    /// </summary>
    public class UserAuthDto
    {
        /// <summary>
        /// Endereço de email
        /// </summary>
        [Required(ErrorMessage = "E-mail é um campo obrigatório para a autenticação")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido")]
        [StringLength(100, ErrorMessage = "E-mail deve conter no máximo {1} caracteres")]
        public required string EmailAddress { get; set; }
    }
}
