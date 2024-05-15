using System.Net;
using Domain.Dtos.Users;
using Domain.Interfaces.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Application.Controllers;

/// <summary>
/// Controlador de usuários
/// </summary>
[Route("[Controller]")]
public class UsersController : Controller
{
    #region Constructors

    /// <summary>
    /// Controlador de usuários
    /// </summary>
    /// <param name=""></param>
    public UsersController(IUserService userService)
    {
        this.userService = userService;
    }

    private IUserService userService;

    #endregion

    #region Members 'EndPoints' :: GetAll(), Get(), Post(), Put(), Delete()

    /// <summary>
    /// Obter todos
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    [Authorize("Bearer")]
    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        try
        {
            if (!this.ModelState.IsValid) return this.BadRequest(this.ModelState);

            return this.Ok(await this.userService.GetAll());
        }
        catch (Exception exception)
        {
            return this.StatusCode((int)HttpStatusCode.InternalServerError, exception.Message);
        }
    }

    /// <summary>
    /// Obter
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [Authorize("Bearer")]
    [HttpGet]
    [Route("{id}", Name = "GetWithId")]
    public async Task<ActionResult> Get(Guid id)
    {
        try
        {
            if (!this.ModelState.IsValid) return this.BadRequest(this.ModelState);

            UserDto? userDto = await this.userService.Get(id);

            return this.Ok(userDto);
        }
        catch (Exception exception)
        {
            return this.StatusCode((int)HttpStatusCode.InternalServerError, exception.Message);
        }
    }

    /// <summary>
    /// Inserir
    /// </summary>
    /// <param name="userDto"></param>
    /// <returns></returns>
    [Authorize("Bearer")]
    [HttpPost("Post")]
    public async Task<ActionResult> Post([FromBody] CreateUserDto userDto)
    {
        try
        {
            if (!this.ModelState.IsValid) return this.BadRequest(this.ModelState);

            CreatedUserDto createdUserDto = await this.userService.Post(userDto);
            bool userHasBeenCreated = createdUserDto != null;
            if (!userHasBeenCreated) return this.BadRequest();

            string link = Url.Link("GetWithId", new { id = createdUserDto!.Id })!;
            Uri uri = new Uri(link);
            return this.Created(uri, createdUserDto);
        }
        catch (Exception exception)
        {
            return this.StatusCode((int)HttpStatusCode.InternalServerError, exception.Message);
        }
    }

    /// <summary>
    /// Atualizar palavra-passe
    /// </summary>
    /// <param name="changeUserPasswordDto"></param>
    /// <returns></returns>
    [Authorize("Bearer")]
    [HttpPost("ChangePassword")]
    public async Task<ActionResult> ChangePassword([FromBody] ChangeUserPasswordDto changeUserPasswordDto)
    {
        try
        {
            if (!this.ModelState.IsValid) return this.BadRequest(this.ModelState);

            UpdatedUserDto? updatedUserDto = await this.userService.ChangePassword(changeUserPasswordDto);
            bool userHasBeenUpdated = updatedUserDto != null;
            if (!userHasBeenUpdated) return this.BadRequest(this.ModelState);

            return this.Ok(updatedUserDto);
        }
        catch (Exception exception)
        {
            return this.StatusCode((int)HttpStatusCode.InternalServerError, exception.Message);
        }
    }

    /// <summary>
    /// Atualizar
    /// </summary>
    /// <param name="userDto"></param>
    /// <returns></returns>
    [Authorize("Bearer")]
    [HttpPut]
    public async Task<ActionResult> Put(Guid id, [FromBody] UpdateUserDto userDto)
    {
        try
        {
            if (id != userDto.Id) return this.NotFound();
            if (!this.ModelState.IsValid) return this.BadRequest(this.ModelState);

            UpdatedUserDto? updatedUserDto = await this.userService.Put(userDto);
            bool userHasBeenUpdated = updatedUserDto != null;
            if (!userHasBeenUpdated) return this.BadRequest();

            return this.Ok(updatedUserDto);
        }
        catch (Exception exception)
        {
            return this.StatusCode((int)HttpStatusCode.InternalServerError, exception.Message);
        }
    }

    /// <summary>
    /// Apagar
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [Authorize("Bearer")]
    [HttpDelete]
    public async Task<ActionResult> Delete(Guid id)
    {
        try
        {
            if (!this.ModelState.IsValid) return this.BadRequest(this.ModelState);

            return this.Ok(await this.userService.Delete(id));
        }
        catch (Exception exception)
        {
            return this.StatusCode((int)HttpStatusCode.InternalServerError, exception.Message);
        }
    }

    #endregion
}