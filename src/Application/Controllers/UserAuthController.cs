using Domain.Dtos.Users;
using Domain.Entities.User;
using Domain.Interfaces.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Application.Controllers
{
    /// <summary>
    /// Controlador de autenticação de usuário
    /// </summary>
    [Route("[Controller]")]
    public class UserAuthController : Controller
    {
        #region Members 'Auth' :: DoUserAuth()

        /// <summary>
        /// Faz autenticação do usuário
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> DoUserAuth([FromBody] UserAuthDto userAuthDto, [FromServices] IUserAuthService userAuthService)
        {
            try
            {
                if (!this.ModelState.IsValid) return this.BadRequest(this.ModelState);
                if (userAuthDto == null) return this.BadRequest(this.ModelState);

                object? result = await userAuthService.DoUserAuth(userAuthDto.EmailAddress);
                if (result == null) return this.NotFound();

                return this.Ok(result);
            }
            catch (Exception exception)
            {
                return this.StatusCode((int)HttpStatusCode.InternalServerError, exception.Message);
            }
        }

        #endregion
    }
}
