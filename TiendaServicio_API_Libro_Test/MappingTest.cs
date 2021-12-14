using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaServicios_Api_Libro.Aplicacion;
using TiendaServicios_Api_Libro.Modelo;

namespace TiendaServicio_API_Libro_Test
{
    class MappingTest : Profile 
    {
        public MappingTest ()
        {
            CreateMap<LibreriaMaterial, LibroMaterialDto>();

        }


    }
}
