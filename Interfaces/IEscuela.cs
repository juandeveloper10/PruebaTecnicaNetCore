using EscuelaMusica.Entidades;

namespace EscuelaMusica.Interfaces
{
    public interface IEscuela
    {
        Task InsertEscuela(Escuela escuela);
        Task UpdateEscuela (Escuela escuela);
        Task<IEnumerable<Escuela>> GetEscuela();
        Task DeleteEscuela ( int  id); 
        Task<Escuela> GetEscuelaById (int id);
    }

}
