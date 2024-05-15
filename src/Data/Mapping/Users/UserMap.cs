using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mapping.Users
{
    /// <summary>
    /// Mapeador Usuário
    /// </summary>
    public class UserMap : IEntityTypeConfiguration<User>
    {
        #region Members 'Configure' :: Configure()

        /// <summary>
        /// Configurar
        /// </summary>
        /// <param name="builder"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Configure(EntityTypeBuilder<User> builder)
        {
            try
            {
                #region 1. Cabeçalho

                builder.ToTable("Users");

                builder.HasKey(x => x.Id);

                #endregion

                #region 2. Requeridos

                builder
                    .Property(x => x.Name)
                    .HasMaxLength(60)
                    .IsRequired();

                builder
                    .Property(x => x.Age)
                    .IsRequired();

                builder
                    .Property(x => x.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(100);

                builder
                    .Property(x => x.Password)
                    .HasMaxLength(50)
                    .IsRequired();

                #endregion

                #region 3. Índices / Chave única

                builder.HasIndex(x => x.Name)
                    .IsUnique();

                builder.HasIndex(x => x.EmailAddress)
                    .IsUnique();

                #endregion
            }
            catch (Exception exception)
            {
                throw new Exception("Fail in Configure(): ", exception);
            }
        }

        #endregion
    }
}
