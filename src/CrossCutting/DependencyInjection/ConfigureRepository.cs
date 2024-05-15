using Data.Repository;
using Data.Repository.Users;
using Domain.Context;
using Domain.Entities.User;
using Domain.Interfaces;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DependencyInjection;

public class ConfigureRepository
{
    /// <summary>
    /// Configurar dependências
    /// </summary>
    /// <param name="serviceCollection"></param>
    /// <exception cref="Exception"></exception>
    public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
    {
        try
        {
            string connectionString = @"Initial Catalog=JuntoSeguros; Data Source=localhost,1450; Persist Security Info=True;User ID=SA;Password= Numsey#2022; TrustServerCertificate=True;";
            serviceCollection.AddDbContext<JuntoSegurosContext>(
                options => options.UseSqlServer(connectionString)
            );

            serviceCollection.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            serviceCollection.AddScoped(typeof(IUserRepository), typeof(UserRepository));
        }
        catch (Exception exception)
        {
            throw new Exception("Fail in ConfigureDependenciesRepository(): ", exception);
        }
    }
}