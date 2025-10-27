using Eventos_PuntoNet.Components.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Eventos_PuntoNet.Components.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Participante> Participantes { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Inscripcion> Inscripciones { get; set; }
        public DbSet<Sensor> Sensores { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Leaderboard> Leaderboards { get; set; }


    }
}
