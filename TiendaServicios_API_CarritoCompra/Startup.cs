using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaServicios_API_CarritoCompra.Persistencia;
using MediatR;
using TiendaServicios_API_CarritoCompra.Aplicacion;
using TiendaServicios_API_CarritoCompra.RemoteInterface;
using TiendaServicios_API_CarritoCompra.RemoteService;

namespace TiendaServicios_API_CarritoCompra
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ILibroService, LibrosService>();
            services.AddControllers();
            services.AddDbContext<CarritoContexto>(options =>
            {
                options.UseMySQL(Configuration.GetConnectionString("ConexionDatabase"));
            });

            services.AddMediatR(typeof(NUEVO.Manejador).Assembly);
            services.AddHttpClient("Libros", config =>
            {
             config.BaseAddress = new Uri(Configuration["Services:Libros"]);

            });


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TiendaServicios_API_CarritoCompra", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TiendaServicios_API_CarritoCompra v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
