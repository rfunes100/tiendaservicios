using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaServicios_Api_Autor.Modelo
{
    public class GradoAcademico
    {
        public int gradoacademicoid { get; set; }
        public string CentroAcademico { get; set; }
        public DateTime FechaGrado { get; set; }


        public int AutorLibroid { get; set; }

        public AutorLibro AutorLibro { get; set; }

        public string GradoAcademicoGuid { get; set; }

    }
}
