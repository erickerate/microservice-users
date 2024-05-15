using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

/// <summary>
/// Entidade base
/// </summary>
public abstract class EntityBase
{
    #region Members 'Header' :: Id

    /// <summary>
    /// Identificador
    /// </summary>
    [Key]
    public virtual Guid Id { get; set; }

    #endregion
}