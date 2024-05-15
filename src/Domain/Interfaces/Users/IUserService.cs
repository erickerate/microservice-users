
using Domain.Dtos.Users;

namespace Domain.Interfaces.Users;

/// <summary>
/// Serviço para usuário
/// </summary>
public interface IUserService : IService<UserDto, CreateUserDto, CreatedUserDto, UpdateUserDto, UpdatedUserDto>
{
    /// <summary>
    /// Alterar palavra-passe
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<UpdatedUserDto?> ChangePassword(ChangeUserPasswordDto changeUserPasswordDto);
}
