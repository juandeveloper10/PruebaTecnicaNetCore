namespace EscuelaMusica.Entidades
{
    public class Profesor
    {
        public int Profesor_Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Profesor_Escuela { get; set; }
    }
}
