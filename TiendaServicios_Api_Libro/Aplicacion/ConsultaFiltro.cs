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
    public class ConsultaFiltro
    {

        public class Librounico : IRequest<LibroMaterialDto>
        {
            public Guid? LibroId { get; set; }
        }

        public class Manejador : IRequestHandler<Librounico, LibroMaterialDto>
        {
            private readonly ContextoLibreria _contexto;
            private readonly IMapper _mapper;

            public Manejador(ContextoLibreria contexto , IMapper mapper )
            {
                _contexto = contexto;
                _mapper = mapper;

            }

            public async Task<LibroMaterialDto> Handle(Librounico request, CancellationToken cancellationToken)
            {
                var libro =  await _contexto.LibreriaMaterial.Where(x => x.LibreriaMaterialId == request.LibroId).FirstOrDefaultAsync();

               if(libro  == null )
                {
                    throw new Exception("No se encontro el libro");

                }

                var librodto = _mapper.Map<LibreriaMaterial, LibroMaterialDto>(libro);

                    return librodto ;
            }
        }


    }
}
