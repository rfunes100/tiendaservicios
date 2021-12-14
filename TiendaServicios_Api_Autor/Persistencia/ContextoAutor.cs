using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaServicios_Api_Autor.Modelo;

namespace TiendaServicios_Api_Autor.Persistencia
{
    public class ContextoAutor : DbContext
    {
        public ContextoAutor(DbContextOptions<ContextoAutor> options ) : base(options) { }
        
            public DbSet<AutorLibro> AutorLbro { get; set; }
            public DbSet<GradoAcademico> GradoAcademico { get; set; }





    }
}
