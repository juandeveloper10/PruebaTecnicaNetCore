using EscuelaMusica.Entidades;

namespace EscuelaMusica.Interfaces
{
    public interface IProfesor
    {
        Task InsertProfesor(Profesor profesor);
        Task UpdateProfesor(Profesor profesor);
        Task<IEnumerable<Profesor>> GetProfesor();
        Task DeleteProfesor(int id);
        Task<Profesor> GetProfesorById(int id);
    }
}
