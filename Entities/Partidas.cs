using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Partidas
    {
        public Partidas()
        {
            SubPartidas = new HashSet<SubPartidas>();
        }

        public int Id { get; set; }
        public int? CantSinClasificar { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Observaciones { get; set; }
        public decimal PesoPromedio { get; set; }
        public string Tipo { get; set; }

        public ICollection<SubPartidas> SubPartidas { get; set; }
    }
}
