using Biblioteca_Virtual.Repository;
using Microsoft.AspNetCore.Identity;

namespace Biblioteca_Virtual.Services.Usuario;

public class UsuarioService: IUsuarioService
{
    private readonly IRepositoryFactory _repositoryFactory;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly PasswordHasher<Entities.Usuario> _hasher;
    //password hasher
    public UsuarioService(IRepositoryFactory repositoryFactory, IHttpContextAccessor httpContextAccessor)
    {
        _repositoryFactory = repositoryFactory;
        _httpContextAccessor = httpContextAccessor;
        _hasher = new PasswordHasher<Entities.Usuario>();
    }

    private int ObtenerIdSesion()
    {
        if (_httpContextAccessor.HttpContext?.User.Identity?.IsAuthenticated == true)
        {
            var idResponsable = _httpContextAccessor.HttpContext.User.FindFirst("UsuarioId")?.Value;
            if (int.TryParse(idResponsable, out int id))
            {
                return id;
            }
        }

        return 1;
    }

    public async Task<List<Entities.Usuario>> ObtenerTodos()
    {
        return await _repositoryFactory.ObtenerRepository<Entities.Usuario>().ObtenerTodos();
    }

    public async Task<Entities.Usuario?> ObtenerPorId(int id)
    {
        return await _repositoryFactory.ObtenerRepository<Entities.Usuario>().ObtenerPorId(id);
    }

    public async Task<Entities.Usuario> Crear(Entities.Usuario entidad)
    {
        entidad.Activo = 1;
        entidad.CreadoPor = ObtenerIdSesion();
        entidad.FechaCreacion = DateTime.Now;
        if (entidad.Contrasenia != null)
        {
            entidad.Contrasenia = _hasher.HashPassword(null, entidad.Contrasenia);
        }
        await _repositoryFactory.ObtenerRepository<Entities.Usuario>().Agregar(entidad);
        return entidad;
    }

    public async Task<Entities.Usuario?> Actualizar(Entities.Usuario entidad)
    {
        entidad.UltimaActualizacion = DateTime.Now;
        await _repositoryFactory.ObtenerRepository<Entities.Usuario>().Actualizar(entidad);
        return entidad;
    }

    public async Task<bool> Eliminar(int id)
    {
        Entities.Usuario usuario =  await _repositoryFactory.ObtenerRepository<Entities.Usuario>().ObtenerPorId(id);
        if (usuario != null)
        {
            usuario.Activo = 0;
            await _repositoryFactory.ObtenerRepository<Entities.Usuario>().Actualizar(usuario);
            return true;
        }
        return false;
    }
}