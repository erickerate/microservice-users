using AutoMapper;
using Domain.Entities.User;
using Domain.Models.Users;

namespace CrossCutting.Mappings;

/// <summary>
/// Modelo -> Entidade
/// </summary>
public class ModelToEntityProfile : Profile
{
    public ModelToEntityProfile()
    {
        // Cliente
        this.CreateMap<UserModel, User>().ReverseMap();
    }
}