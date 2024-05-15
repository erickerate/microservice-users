using Domain.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository;

/// <summary>
/// Implementação do repositório utilizando EntityFramework
/// </summary>
/// <typeparam name="T"></typeparam>
public class Repository<T> : IRepository<T>
    where T : EntityBase
{
    #region Constructors

    /// <summary>
    /// Repositório base
    /// </summary>
    /// <param name=""></param>
    public Repository(JuntoSegurosContext context)
    {
        this.Context = context;
        this.DataSet = this.Context.Set<T>();
    }

    #endregion

    #region Members 'Context' :: Context, dataSet

    /// <summary>
    /// Contexto
    /// </summary>
    protected readonly JuntoSegurosContext Context;

    /// <summary>
    /// Dados
    /// </summary>
    protected readonly DbSet<T> DataSet;

    #endregion

    #region Members 'IRepository' :: InsertAsync(), UpdateAsync(), DeleteAsync(), SelectAsync(), ExistAsync()

    /// <summary>
    /// Inserir
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task<T> InsertAsync(T entity)
    {
        try
        {
            if (entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
            }

            this.DataSet.Add(entity);

            await this.Context.SaveChangesAsync();

            return entity;
        }
        catch (DbUpdateException)
        {
            throw;
        }
        catch (Exception exception)
        {
            throw new Exception("Fail in InsertAsync(): ", exception);
        }
    }

    /// <summary>
    /// Atualizar
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task<T?> UpdateAsync(T entity)
    {
        try
        {
            T? existentEntity = await this.DataSet.SingleOrDefaultAsync(w => w.Id.Equals(entity.Id));

            bool entityExists = existentEntity != null;
            if (!entityExists) return null;

            this.Context.Entry(existentEntity!).CurrentValues.SetValues(entity);
            await this.Context.SaveChangesAsync();

            return entity;
        }
        catch (Exception exception)
        {
            throw new Exception("Fail in UpdateAsync(): ", exception);
        }
    }

    /// <summary>
    /// Apagar
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<bool> DeleteAsync(Guid id)
    {
        try
        {
            T? existentEntity = await this.DataSet.SingleOrDefaultAsync(w => w.Id.Equals(id));

            bool entityExists = existentEntity != null;
            if (!entityExists) return false;

            this.DataSet.Remove(existentEntity!);
            await this.Context.SaveChangesAsync();

            return true;
        }
        catch (Exception exception)
        {
            throw new Exception("Fail in DeleteAsync(): ", exception);
        }
    }

    /// <summary>
    /// Selecionar
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<T?> SelectAsync(Guid id)
    {
        try
        {
            return await this.DataSet.SingleOrDefaultAsync(w => w.Id.Equals(id));
        }
        catch (Exception exception)
        {
            throw new Exception("Fail in SelectAsync(): ", exception);
        }
    }

    /// <summary>
    /// Selecionar
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<T>> SelectAsync()
    {
        try
        {
            return await this.DataSet.ToListAsync();
        }
        catch (Exception exception)
        {
            throw new Exception("Fail in SelectAsync(): ", exception);
        }
    }

    /// <summary>
    /// Existe?
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<bool> ExistAsync(Guid id)
    {
        try
        {
            return this.DataSet.AnyAsync(w => w.Id.Equals(id));
        }
        catch (Exception exception)
        {
            throw new Exception("Fail in ExistAsync(): ", exception);
        }
    }

    #endregion
}