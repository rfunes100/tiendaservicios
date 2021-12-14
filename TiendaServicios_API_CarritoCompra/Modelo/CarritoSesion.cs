﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaServicios_API_CarritoCompra.Modelo
{
    public class CarritoSesion
    {

        public int CarritoSesionId { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public ICollection<CarritoSesionDetalle> ListaDetalle { get; set; }



    }
}
