using Domain.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.Context;

/// <summary>
/// Contexto em tempo de execução
/// </summary>
public class ContextFactory : IDesignTimeDbContextFactory<JuntoSegurosContext>
{
    #region Members 'Override' :: CreateDbContext()

    /// <summary>
    /// Criar contexto
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public JuntoSegurosContext CreateDbContext(string[] args)
    {
        try
        {
            string connectionString = @"Initial Catalog=JuntoSeguros; Data Source=localhost,1450; Persist Security Info=True;User ID=SA;Password= Numsey#2022; TrustServerCertificate=True;";
            DbContextOptionsBuilder<JuntoSegurosContext> optionsBuilder = new DbContextOptionsBuilder<JuntoSegurosContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new JuntoSegurosContext(optionsBuilder.Options);
        }
        catch (Exception exception)
        {
            throw new Exception("Fail in CreateDbContext(): ", exception);
        }
    }

    #endregion
}