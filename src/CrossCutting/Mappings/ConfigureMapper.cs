using Data.Repository;
using Domain.Context;
using Domain.Entities;
using Domain.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.Mappings;

public class ConfigureMapper
{
    /// <summary>
    /// Configurar mapeamento
    /// </summary>
    /// <param name="serviceCollection"></param>
    /// <exception cref="Exception"></exception>
    public static void ConfigureDependenciesMapping(IServiceCollection serviceCollection)
    {
        try
        {
            AutoMapper.MapperConfiguration config = new AutoMapper.MapperConfiguration(config =>
            {
                config.AddProfile(new DtoToModelProfile());
                config.AddProfile(new EntityToDtoProfile());
                config.AddProfile(new ModelToEntityProfile());
            });
            IMapper mapper = config.CreateMapper();
            serviceCollection.AddSingleton(mapper);
        }
        catch (Exception exception)
        {
            throw new Exception("Fail in ConfigureDependenciesMapping(): ", exception);
        }
    }
}