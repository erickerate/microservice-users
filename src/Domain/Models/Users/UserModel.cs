namespace Domain.Models.Users;

/// <summary>
/// Modelo de usuário
/// </summary>
public class UserModel
{
    /// <summary>
    /// Identificador
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Nome
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Idade
    /// </summary>
    public int? Age { get; set; }

    /// <summary>
    /// Email
    /// </summary>
    public string? EmailAddress { get; set; }

    /// <summary>
    /// Palvra-passe
    /// </summary>
    public string? Password { get; set; }
}