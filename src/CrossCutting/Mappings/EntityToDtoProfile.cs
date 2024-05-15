using AutoMapper;
using Domain.Dtos.Users;
using Domain.Entities.User;

namespace CrossCutting.Mappings;

/// <summary>
/// Entidade -> Dto
/// </summary>
public class EntityToDtoProfile : Profile
{
    public EntityToDtoProfile()
    {
        // Usuário
        this.CreateMap<User, UserDto>().ReverseMap();
        this.CreateMap<User, CreateUserDto>().ReverseMap();
        this.CreateMap<User, CreatedUserDto>().ReverseMap();
        this.CreateMap<User, UpdateUserDto>().ReverseMap();
        this.CreateMap<User, UpdatedUserDto>().ReverseMap();
    }
}