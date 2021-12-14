using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios_Api_Libro.Modelo;
using TiendaServicios_Api_Libro.Persistencia;

namespace TiendaServicios_Api_Libro.Aplicacion
{
    public class Consulta
    {
        public class Ejecuta : IRequest<List<LibroMaterialDto>> { }

        public class Manejador : IRequestHandler<Ejecuta, List<LibroMaterialDto>>
        {
            private readonly ContextoLibreria _contexto;
            private readonly IMapper _mapper;

            public Manejador( ContextoLibreria contexto ,  IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper; 
                  
            }

            public async  Task<List<LibroMaterialDto>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var Libros = await _contexto.LibreriaMaterial.ToListAsync();

                var librosdto = _mapper.Map<List<LibreriaMaterial>, List<LibroMaterialDto>>(Libros);

                return librosdto;

            }
        }
    }
}
