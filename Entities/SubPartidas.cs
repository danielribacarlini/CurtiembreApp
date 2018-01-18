using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class SubPartidas
    {
        public SubPartidas()
        {
            ProcesosHumedos = new HashSet<ProcesosHumedos>();
        }

        public int Id { get; set; }
        public int Calidad { get; set; }
        public int CantCueros { get; set; }
        public decimal? Eficiencia { get; set; }
        public string Estado { get; set; }
        public int PartidaId { get; set; }
        public int? PedidoId { get; set; }
        public int? Stock { get; set; }

        public Partidas Partida { get; set; }
        public Pedidos Pedido { get; set; }
        public ICollection<ProcesosHumedos> ProcesosHumedos { get; set; }
    }
}
