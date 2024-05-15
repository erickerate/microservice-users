using System;
using Data.Mapping.Users;
using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Domain.Context;

/// <summary>
/// Contexto
/// </summary>
public partial class JuntoSegurosContext : DbContext
{
    #region Constructors

    /// <summary>
    /// Contexto
    /// </summary>
    /// <param name="options"></param>
    public JuntoSegurosContext(DbContextOptions<JuntoSegurosContext> options)
        : base(options)
    {
    }

    #endregion

    #region Members 'Collections' :: User

    /// <summary>
    /// Usuários
    /// </summary>
    public virtual DbSet<User> Users { get; set; }

    #endregion

    #region Members 'Overrides' :: OnModelCreating()
    
    /// <summary>
    /// Ao criar modelo
    /// </summary>
    /// <param name="modelBuilder"></param>
    /// <exception cref="Exception"></exception>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        try
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(new UserMap().Configure);

            // Usuário admin
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Administrador",
                    Age = 999,
                    EmailAddress = "admin@juntoseguros.com.br",
                    Password = "10",
                }
            );
        }
        catch(Exception exception)
        {
            throw new Exception("Fail in OnModelCreating(): ", exception);
        }
    }

    #endregion
}