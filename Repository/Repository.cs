using Biblioteca_Virtual.Context;
using Biblioteca_Virtual.Entities;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca_Virtual.Repository;

public class Repository<T>: IRepository<T> where T: class
{
    private readonly MyDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(MyDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<List<T>> ObtenerTodos()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T?> ObtenerPorId(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task Agregar(T entidad)
    {
        _dbSet.Add(entidad);
        await _context.SaveChangesAsync();
    }

    public async Task Actualizar(T entidad)
    {
        var entry = _context.Entry(entidad);
        if (entry.State == EntityState.Detached)
        {
            _dbSet.Attach(entidad);
        }

        entry.State = EntityState.Modified;

        await _context.SaveChangesAsync();
    }

    // Se usa "Update" en lugar de "Remove" Para aplicar la eliminacion logica (solo se cambia el atributo activo)
    public async Task Eliminar(T entidad)
    {
        _dbSet.Remove(entidad);
        await _context.SaveChangesAsync();
    }
}