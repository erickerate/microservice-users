using Data.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UserMicroservice.Service;

namespace CrossCutting.DependencyInjection;

public class ConfigureService
{
    /// <summary>
    /// Configurar dependências
    /// </summary>
    /// <param name="serviceCollection"></param>
    /// <exception cref="Exception"></exception>
    public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
    {
        try
        {
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<IUserAuthService, UserAuthService>();
        }
        catch (Exception exception)
        {
            throw new Exception("Fail in ConfigureDependenciesService(): ", exception);
        }
    }
}