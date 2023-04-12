using Microsoft.EntityFrameworkCore;
using UniqueApi.Models;

namespace UniqueApi.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<TipoServicio> TipoServicios=> Set<TipoServicio>();
        public DbSet<Servicio> Servicios => Set<Servicio>();
        public DbSet<Cita> Cita => Set<Cita>();
        public DbSet<Estado> Estados=> Set<Estado>();

       
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Estado>().HasData(
                new Estado
                {
                    EstadoId = 1,
                    Descripcion= "En espera"
                },
                new Estado { 
                    EstadoId =2,
                    Descripcion= "Cancelado"
                },
                new Estado
                {
                    EstadoId =3,
                    Descripcion= "Finalizado"
                }

                );
        }
    }
    
}
