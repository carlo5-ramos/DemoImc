using SQLite;

namespace DemoIMC.Models
{
    public class Usuarios
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        public int Edad { get; set; }
        public double Peso { get; set; }
        public double Estatura { get; set; }
    }
}
