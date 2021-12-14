using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TiendaServicios_Api_Autor.Modelo;
using Microsoft.EntityFrameworkCore;
using TiendaServicios_Api_Autor.Persistencia;
using AutoMapper;

namespace TiendaServicios_Api_Autor.Aplicacion
{
    public class ConsultaFiltro
    {

        public class AutorUnico : IRequest<AutorDto>
        {
            public string AutorGuid { get; set; }
        }

        public class Manejador : IRequestHandler<AutorUnico, AutorDto>
        {
            private readonly ContextoAutor _contexto;
            private readonly IMapper _mapper;

            public Manejador(ContextoAutor contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;

            }
            //AutorLibro
            public async Task<AutorDto> Handle(AutorUnico request, CancellationToken cancellationToken)
            {
                var autor = await  _contexto.AutorLbro.Where(x => x.AutorLibroGuid == request.AutorGuid).FirstOrDefaultAsync();
                if( autor == null)
                {
                    throw new Exception("No se encontro el autor");
                }
                var autordto = _mapper.Map<AutorLibro, AutorDto>(autor);

                return autordto;
            }
        }
    }
}
