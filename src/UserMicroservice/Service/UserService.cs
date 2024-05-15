using Domain.Dtos.Users;
using Domain.Interfaces;
using Domain.Interfaces.Users;
using Domain.Models.Users;
using AutoMapper;
using Domain.Entities.User;
using Domain.Repositories;

namespace UserMicroservice.Service;

/// <summary>
/// Serviço para usuário
/// </summary>
public class UserService : IUserService
{
    #region Constructors

    /// <summary>
    /// Serviço para usuário
    /// </summary>
    /// <param name=""></param>
    public UserService(IUserRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    #endregion

    #region Members 'Dependencies' :: repository, mapper

    /// <summary>
    /// Repositório
    /// </summary>
    private readonly IUserRepository repository;

    /// <summary>
    /// Mapeador
    /// </summary>
    private readonly IMapper mapper;

    #endregion

    #region Members 'IService' :: Get(), GetAll(), Post(), Put(), Delete()

    /// <summary>
    /// Obter
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<UserDto?> Get(Guid id)
    {
        try
        {
            User? user = await this.repository.SelectAsync(id);
            return this.mapper.Map<UserDto>(user);
        }
        catch (Exception exception)
        {
            throw new Exception("Fail in Get(): ", exception);
        }
    }

    /// <summary>
    /// Obter todos
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<IEnumerable<UserDto>> GetAll()
    {
        try
        {
            IEnumerable<User> users = await this.repository.SelectAsync();
            return this.mapper.Map<IEnumerable<UserDto>>(users);
        }
        catch (Exception exception)
        {
            throw new Exception("Fail in GetAll(): ", exception);
        }
    }

    /// <summary>
    /// Inserir
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public async Task<CreatedUserDto> Post(CreateUserDto item)
    {
        try
        {
            UserModel userModel = this.mapper.Map<UserModel>(item);
            User user = this.mapper.Map<User>(userModel);
            User addedUser = await this.repository.InsertAsync(user);
            return this.mapper.Map<CreatedUserDto>(addedUser);
        }
        catch (Exception exception)
        {
            throw new Exception("Fail in Post(): ", exception);
        }
    }

    /// <summary>
    /// Atualizar
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public async Task<UpdatedUserDto?> Put(UpdateUserDto item)
    {
        try
        {
            UserModel userModel = this.mapper.Map<UserModel>(item);
            User user = this.mapper.Map<User>(userModel);
            User? updatedUser = await this.repository.UpdateAsync(user);
            return this.mapper.Map<UpdatedUserDto>(updatedUser);
        }
        catch (Exception exception)
        {
            throw new Exception("Fail in Put(): ", exception);
        }
    }

    /// <summary>
    /// Apagar
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<bool> Delete(Guid id)
    {
        try
        {
            return await this.repository.DeleteAsync(id);
        }
        catch (Exception exception)
        {
            throw new Exception("Fail in Delete(): ", exception);
        }
    }

    /// <summary>
    /// Alterar palavra passe
    /// </summary>
    /// <param name="changeUserPasswordDto"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<UpdatedUserDto?> ChangePassword(ChangeUserPasswordDto changeUserPasswordDto)
    {
        try
        {
            User? existentUser = await this.repository.SelectAsync(changeUserPasswordDto.Id);
            bool userExists = existentUser != null;
            if (!userExists) return null;

            bool passwordMatched = changeUserPasswordDto.CurrentPassword == existentUser!.Password;
            if (!passwordMatched) return null;

            existentUser.Password = changeUserPasswordDto.NewPassword;
            User? updatedUser = await this.repository.UpdateAsync(existentUser);

            return this.mapper.Map<UpdatedUserDto>(updatedUser);
        }
        catch (Exception exception)
        {
            throw new Exception("Fail in ChangePassword(): ", exception);
        }
    }

    #endregion
}