namespace Biblioteca_Virtual.Services.Usuario;

public interface IUsuarioService
{
    Task<List<Entities.Usuario>> ObtenerTodos();
    Task<Entities.Usuario?> ObtenerPorId(int id);
    Task<Entities.Usuario> Crear(Entities.Usuario entidad);
    Task<Entities.Usuario?> Actualizar(Entities.Usuario entidad);
    Task<bool> Eliminar(int id);
}