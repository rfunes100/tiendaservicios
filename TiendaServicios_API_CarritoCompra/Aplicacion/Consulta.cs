using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios_API_CarritoCompra.Persistencia;
using TiendaServicios_API_CarritoCompra.RemoteInterface;

namespace TiendaServicios_API_CarritoCompra.Aplicacion
{
    public class Consulta
    {
        public class Ejecuta : IRequest<CarritoDto>
        {
            public int CarritoSesionId { get; set; }

        }
        public class Manejador : IRequestHandler<Ejecuta, CarritoDto>
        {
            private readonly CarritoContexto _contexto;
            private readonly ILibroService _LibroService;

            public Manejador(CarritoContexto contexto, ILibroService libroservice)
            {
                _contexto = contexto;
                _LibroService = libroservice;
            }


            public async Task<CarritoDto> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var carritosesion = await _contexto.CarritoSesion.FirstOrDefaultAsync(
                     x => x.CarritoSesionId == request.CarritoSesionId
                    );

                var carritoSesionDetalle = await _contexto.CarritoSesionDetalle.Where(
                     x => x.CarritoSesionId == request.CarritoSesionId
                    ).ToListAsync();

                var listacarritoDto = new List<CarritoDetalledto>();

                foreach (var libro in carritoSesionDetalle)
                {
                    var response = await _LibroService.GetLibro(new Guid(libro.ProductoSeleccionado));
                    if (response.resultado)
                    {
                        var ObjetoLibro = response.Libro;
                        var carritoDetalle = new CarritoDetalledto
                        {
                            TituloLibro = ObjetoLibro.Titulo,
                               
                            FechaPublicacion = ObjetoLibro.FechaPublicacion, 
                            LibroId = ObjetoLibro.LibreriaMaterialId
                        };
                        listacarritoDto.Add(carritoDetalle);

                    }
                }

                var carritoSesionDto = new CarritoDto
                {
                    CarritoId = carritosesion.CarritoSesionId,
                    FechaCreacionSesion = carritosesion.FechaCreacion,
                    ListaProductos = listacarritoDto
                };

                return carritoSesionDto;





            }
        }
    }
}
