using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios_API_CarritoCompra.Modelo;
using TiendaServicios_API_CarritoCompra.Persistencia;

namespace TiendaServicios_API_CarritoCompra.Aplicacion
{
    public class NUEVO

    {
        public class ejecuta : IRequest
        {
            public DateTime FechaCreacion { get; set; }

            public List<string> ProductoLista { get; set; }



        }

        public class Manejador : IRequestHandler<ejecuta>
        {
            private  readonly CarritoContexto  _contexto;
               

                public Manejador(CarritoContexto contexto)
            {
                _contexto = contexto;
            }

            public async  Task<Unit> Handle(ejecuta request, CancellationToken cancellationToken)
            {
                var carritosesion = new CarritoSesion
                {
                    FechaCreacion = request.FechaCreacion
                };

                _contexto.CarritoSesion.Add(carritosesion);
              var value =   await  _contexto.SaveChangesAsync();
                 if(value == 0)
                {
                    throw new Exception("Errores en la insercion del carritos de compras");

                }

                int id = carritosesion.CarritoSesionId;

                foreach(var obj in request.ProductoLista)
                {
                    var detallesesion = new CarritoSesionDetalle
                    {
                        FechaCreacion = DateTime.Now,
                        CarritoSesionId = id,
                        ProductoSeleccionado = obj
                    };
                    _contexto.CarritoSesionDetalle.Add(detallesesion);
                    

                }

              value = await  _contexto.SaveChangesAsync();

                if(value > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se puedo ingresar el detalle en el carrito de compra");

            }
        }
    }
}
