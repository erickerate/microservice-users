
using Domain.Entities;

namespace Domain.Interfaces;

/// <summary>
/// Repositório genérico
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IRepository<T>
    where T : EntityBase
{
    /// <summary>
    /// Inserir
    /// </summary>
    /// <returns></returns>
    Task<T> InsertAsync(T entity);

    /// <summary>
    /// Atualizar
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task<T?> UpdateAsync(T entity);

    /// <summary>
    /// Apagar
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> DeleteAsync(Guid id);

    /// <summary>
    /// Consultar
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<T?> SelectAsync(Guid id);

    /// <summary>
    /// Consultar
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<T>> SelectAsync();

    /// <summary>
    /// Existe?
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> ExistAsync(Guid id);
}