using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaServicios_API_CarritoCompra.Aplicacion;

namespace TiendaServicios_API_CarritoCompra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoComprasController : ControllerBase
    {

        private readonly IMediator _mediator;

        public CarritoComprasController(IMediator mediator)
        {
            _mediator = mediator; 
        }

        [HttpPost]
            public async Task<ActionResult<Unit>> Crear(NUEVO.ejecuta data )
        {
            return await _mediator.Send(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarritoDto>> GetCarito( int id )
        {
            return await _mediator.Send(new Consulta.Ejecuta { CarritoSesionId = id });

        }
    }
}
