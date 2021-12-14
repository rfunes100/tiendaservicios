using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaServicios_Api_Libro.Aplicacion
{
    public class LibroMaterialDto
    {

        public string Titulo { get; set; }
        public DateTime? FechaPublicacion { get; set; }
        public Guid? AutorLibro { get; set; }
        public Guid? LibreriaMaterialId { get; set; }

    }


}
