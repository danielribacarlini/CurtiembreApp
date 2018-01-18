using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace Entities
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            
        }

        public DbSet<Partida> Partidas { get; set; }
        public DbSet<SubPartida> SubPartidas { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ProcesoHumedo> ProcesosHumedos { get; set; }
        public DbSet<Operario> Operarios { get; set; }
        public DbSet<RecetaHumeda> RecetaHumedas { get; set; }
        public DbSet<ItemReceta> ItemsReceta { get; set; }
        public DbSet<Insumo> Insumos { get; set; }

    }
}
