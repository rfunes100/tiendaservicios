using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaServicios_Api_Autor.Aplicacion
{
    public class AutorDto
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public DateTime? fechaNacimiento { get; set; }

        public string AutorLibroGuid { get; set; }


    }
}
