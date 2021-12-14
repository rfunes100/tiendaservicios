﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaServicios_API_CarritoCompra.Modelo
{
    public class CarritoSesionDetalle
    {
        public int CarritoSesionDetalleId { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public string ProductoSeleccionado { get; set; }

        public int CarritoSesionId { get; set; }

        public CarritoSesion CarritosSesion { get; set; }



    }
}
