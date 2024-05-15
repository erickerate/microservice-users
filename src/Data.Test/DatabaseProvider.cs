using System;
using Domain.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Data.Test
{
    /// <summary>
    /// Provedor banco de dados
    /// </summary>
    public class DatabaseProvider : IDisposable
    {
        #region Constructors

        /// <summary>
        /// Provedor banco de dados
        /// </summary>
        public DatabaseProvider()
        {
            string connectionString = $@"Initial Catalog={this.dataBaseName}; Data Source=sqldata; Persist Security Info=True;User ID=SA;Password= Numsey#2022; TrustServerCertificate=True;";
            ServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<JuntoSegurosContext>(
                o => o.UseSqlServer(connectionString),
                ServiceLifetime.Transient
            );

            this.ServiceProvider = serviceCollection.BuildServiceProvider();
            using (JuntoSegurosContext? context = this.ServiceProvider.GetService<JuntoSegurosContext>())
            {
                context!.Database.EnsureCreated();
            }
        }
        private string dataBaseName = $"JuntoSeguros.Test_{Guid.NewGuid().ToString().Replace("-", string.Empty)}";

        #endregion

        #region Members 'Dependencies' :: ServiceProvider

        /// <summary>
        /// Provedor
        /// </summary>
        public ServiceProvider ServiceProvider { get; private set; }

        #endregion

        #region Members 'Disposable' :: Dispose()

        /// <summary>
        /// Descartar
        /// </summary>
        public void Dispose()
        {
            using (JuntoSegurosContext? context = this.ServiceProvider.GetService<JuntoSegurosContext>())
            {
                context!.Database.EnsureDeleted();
            }
        }

        #endregion
    }

}
