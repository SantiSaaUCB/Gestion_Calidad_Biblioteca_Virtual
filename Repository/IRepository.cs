using Biblioteca_Virtual.Context;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca_Virtual.Repository;

public interface IRepository<T> where T : class
{
    public Task<List<T>> ObtenerTodos();
    Task<T?> ObtenerPorId(int id);
    Task Agregar(T entidad);
    Task Actualizar(T entidad);
    Task Eliminar(T entidad);
    
}