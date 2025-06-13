using EscuelaMusica.Entidades;
using EscuelaMusica.Interfaces;
using Microsoft.Data.SqlClient;

namespace EscuelaMusica.Repository
{
    public class ProfesorRepository(IConfiguration config) : IProfesor
    {
        private string connectionString = config.GetConnectionString("Default");
        public async Task DeleteProfesor(int id)
        {
            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand("sp_delete_Profesor", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure

            };
            command.Parameters.AddWithValue("@Profesor_Id", id);
            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }

       

        public async Task<IEnumerable<Profesor>> GetProfesor()
        {
            var profesor = new List<Profesor>();
            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand("sp_SelectAll_Profesor", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure

            };
            await connection.OpenAsync();
            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                profesor.Add(new Profesor
                {
                    Profesor_Id = reader.GetInt32(0),
                    Nombre = reader.GetString(1),
                    Apellido = reader.GetString(2),
                    FechaNacimiento = reader.GetDateTime(3),
                    Profesor_Escuela = reader.GetInt32(4),

                });




            }
            return profesor;

        }

        public async Task<Profesor> GetProfesorById(int id)
        {
            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand("sp_SelectId_Profesor", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure

            };
            command.Parameters.AddWithValue("@Profesor_Id", id);
            await connection.OpenAsync();
            using var reader = await command.ExecuteReaderAsync();
            Profesor _profesor= new();
            while (await reader.ReadAsync())
            {
                _profesor = new()
                {
                    Profesor_Id = reader.GetInt32(0),
                    Nombre = reader.GetString(1),
                    Apellido = reader.GetString(2),
                    FechaNacimiento = reader.GetDateTime(3),
                    Profesor_Escuela = reader.GetInt32(4),

                };
            }
            return _profesor;

        }

     

       
        public async Task InsertProfesor(Profesor profesor)
        {
            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand("sp_Ins_Profesor", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure

            };
            command.Parameters.AddWithValue("@Nombre", profesor.Nombre);
            command.Parameters.AddWithValue("@Apellido", profesor.Apellido);
            command.Parameters.AddWithValue("@FechaNacimiento", profesor.FechaNacimiento);
            command.Parameters.AddWithValue("@Profesor_Escuela", profesor.Profesor_Escuela);
            await connection.OpenAsync();
            await command.ExecuteReaderAsync();
        }

       
        public async Task UpdateProfesor(Profesor profesor)
        {
            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand("sp_Update_Profesor", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure

            };
            command.Parameters.AddWithValue("@Escuela_Id", profesor.Profesor_Id);
            command.Parameters.AddWithValue("@Nombre", profesor.Nombre);
            command.Parameters.AddWithValue("@Apellido", profesor.Apellido);
            command.Parameters.AddWithValue("@FechaNacimiento", profesor.FechaNacimiento);
            command.Parameters.AddWithValue("@Profesor_Escuela", profesor.Profesor_Escuela);
            await connection.OpenAsync();
            await command.ExecuteReaderAsync();
        }

       
    }
}
