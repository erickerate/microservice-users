using AutoMapper;
using Domain.Dtos.Users;
using Domain.Models.Users;

namespace CrossCutting.Mappings;

/// <summary>
/// Dto -> Modelo
/// </summary>
public class DtoToModelProfile : Profile
{
    public DtoToModelProfile()
    {
        // Usuário
        this.CreateMap<UserDto, UserModel>().ReverseMap();
        this.CreateMap<CreateUserDto, UserModel>().ReverseMap();
        this.CreateMap<UpdateUserDto, UserModel>().ReverseMap();
    }
}