using SQLite;
using SQLiteNetExtensions.Attributes;
using System;

namespace DemoIMC.Models
{
    public class Imcs
    {
        [PrimaryKey, AutoIncrement]
        public int ImcID { get; set; }

        [ForeignKey(typeof(Usuarios))]
        public int UsuarioID { get; set; }

        public string NombreUser { get; set; }
        public string ApellidoUser { get; set; }
        public string SexoUser { get; set; }
        public int EdadUser { get; set; }
        public double PesoUser { get; set; }
        public double EstaturaUser { get; set; }

        public double Imc { get; set; }
     
        public DateTime FechaRegistro { get; set; }
    }
}
