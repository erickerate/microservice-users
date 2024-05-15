
namespace Domain.Interfaces;

/// <summary>
/// Serviço
/// </summary>
public interface IService<Dto, CreateDto, CreatedDto, UpdateDto, UpdatedDto>
{
    /// <summary>
    /// Obter
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Dto?> Get(Guid id);

    /// <summary>
    /// Obter todos
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<Dto>> GetAll();

    /// <summary>
    /// Inserir
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    Task<CreatedDto> Post(CreateDto item);

    /// <summary>
    /// Atualizar
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    Task<UpdatedDto?> Put(UpdateDto item);

    /// <summary>
    /// Apagar
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> Delete(Guid id);
}