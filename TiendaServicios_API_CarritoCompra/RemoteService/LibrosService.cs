using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TiendaServicios_API_CarritoCompra.RemoteInterface;
using TiendaServicios_API_CarritoCompra.RemoteModel;

namespace TiendaServicios_API_CarritoCompra.RemoteService
{
    public class LibrosService : ILibroService
    {

        private readonly IHttpClientFactory _httpClient;
        private readonly ILogger<LibrosService> _logger; 
        
        public LibrosService(IHttpClientFactory httpclient , ILogger<LibrosService> logger)
        {
            _httpClient = httpclient;
            _logger = logger;
        }

        public async  Task<(bool resultado, LibroRemote Libro, string ErrorMesage)> GetLibro(Guid LibroId)
        {
            try
            {
                var cliente = _httpClient.CreateClient("Libros");
              var response = await  cliente.GetAsync($"api/LibroMaterial/{LibroId}");
               if (response.IsSuccessStatusCode)
                {
                    var contenido = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var resultado = JsonSerializer.Deserialize<LibroRemote>(contenido, options);
                    return (true, resultado, null);
                }

                return (false, null, response.ReasonPhrase);

            }
            catch ( Exception e)
            {
                _logger.LogError(e.ToString());
                return (false, null, e.Message);
            }
        }
    }
}
