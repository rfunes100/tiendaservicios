using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaServicios_API_CarritoCompra.RemoteModel;

namespace TiendaServicios_API_CarritoCompra.RemoteInterface
{
   public  interface ILibroService
    {

        Task<(bool resultado , LibroRemote Libro, string ErrorMesage)> GetLibro(Guid LibroId);

    }
}
