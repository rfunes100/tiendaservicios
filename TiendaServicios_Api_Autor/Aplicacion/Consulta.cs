using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TiendaServicios_Api_Autor.Modelo;
using TiendaServicios_Api_Autor.Persistencia;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace TiendaServicios_Api_Autor.Aplicacion
{
    public class Consulta
    {

        public class ListaAutor : IRequest<List<AutorDto>> { }

        public class Manejador : IRequestHandler<ListaAutor, List<AutorDto>>
        {
            private readonly ContextoAutor  _contexto;
            private readonly IMapper _mapper; 

            public Manejador(ContextoAutor contexto , IMapper mapper )
            {
                _contexto = contexto;
                _mapper = mapper;

            }

            public async  Task<List<AutorDto>> Handle(ListaAutor request, CancellationToken cancellationToken)
            {
                  var autores = await _contexto.AutorLbro.ToListAsync();
                var autoresDto = _mapper.Map<List<AutorLibro>, List<AutorDto>> (autores);

                return autoresDto; 
            }
        }
    }
}
