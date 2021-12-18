using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppEmpleados.Models
{
   public class Empleado
    {
        [PrimaryKey, AutoIncrement]
        public int codigo { get; set; }
        [MaxLength(255)]
        public String Nombre { get; set; }
        [MaxLength(255)]

        public String Apellidos { get; set; }
      
        [MaxLength(2)]
        public int  Edad { get; set; }

        [MaxLength(255)]
        public String Direccion { get; set; }
        [MaxLength(255)]
        public String Puesto { get; set; }
    }
}
