namespace Biblioteca_Virtual.Repository;

public interface IRepositoryFactory
{
    IRepository<T> ObtenerRepository<T>() where T : class;
    
    //Otras implementaciones de repositorios especiales
}