using Domain.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.Migrations
{
    /// <summary>
    /// Configurar banco de dados
    /// </summary>
    public static class ConfigureDatabase
    {
        /// <summary>
        /// Fazer migração inicial
        /// </summary>
        /// <param name="serviceProvider"></param>
        public static void DoInitialMigrate(this IServiceProvider serviceProvider)
        {
            using (IServiceScope serviceScope = serviceProvider.CreateScope())
            {
                JuntoSegurosContext? context = serviceScope.ServiceProvider.GetService<JuntoSegurosContext>();
                context!.Database.Migrate();
            }
        }
    }
}
