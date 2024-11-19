using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ENT;

namespace Ejercicio02ASP.Data
{
    public class Ejercicio02ASPContext : DbContext
    {
        public Ejercicio02ASPContext (DbContextOptions<Ejercicio02ASPContext> options)
            : base(options)
        {
        }

        public DbSet<ENT.clsPersona> Personas { get; set; } = default!;
    }
}
