using EscuelaMusica.Entidades;
using EscuelaMusica.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EscuelaMusica.Repository
{
    public class EscuelaRepository(IConfiguration config) : IEscuela
    {
        private string connectionString = config.GetConnectionString("Default");
        public async Task DeleteEscuela(int id)
        {
            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand("sp_delete_Escuela", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure

            };
            command.Parameters.AddWithValue("@Escuela_Id", id);
            await connection.OpenAsync();   
            await command.ExecuteNonQueryAsync();    
         }
        public async Task<IEnumerable<Escuela>> GetEscuela()
        {
            var escuela = new List<Escuela>();
            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand("sp_SelectAll_Escuela", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure

            };
            await connection.OpenAsync();
            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                escuela.Add(new Escuela
                {
                    Escuela_Id = reader.GetInt32(0),
                    Nombre = reader.GetString(1),
                    Descripcion = reader.GetString(2)   
                });




            }
            return escuela;

        }

        public async Task<Escuela> GetEscuelaById(int id)
        {
            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand("sp_SelectId_Escuela", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure

            };
            command.Parameters.AddWithValue("@Escuela_Id", id);
            await connection.OpenAsync();
            using var reader  = await command.ExecuteReaderAsync();
            Escuela _escuela = new();
            while(await  reader.ReadAsync())
            {
                _escuela = new ()
                {
                    Escuela_Id = reader.GetInt32(0),
                    Nombre = reader.GetString(1),
                    Descripcion = reader.GetString(2)

                };
            }
            return _escuela; 

        }

        public async Task InsertEscuela(Escuela escuela)
        {
            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand("sp_Ins_Profesor", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure

            };
            command.Parameters.AddWithValue("@Nombre", escuela.Nombre);
            command.Parameters.AddWithValue("@Descripcion", escuela.Descripcion);
            await connection.OpenAsync();
            await command.ExecuteReaderAsync(); 
        }

        public async Task UpdateEscuela(Escuela escuela)
        {
            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand("sp_Update_Escuela", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure

            };
            command.Parameters.AddWithValue("@Escuela_Id", escuela.Escuela_Id);
            command.Parameters.AddWithValue("@Nombre", escuela.Nombre);
            command.Parameters.AddWithValue("@Descripcion", escuela.Descripcion);
            await connection.OpenAsync();
            await command.ExecuteReaderAsync();
        }
    }
}
