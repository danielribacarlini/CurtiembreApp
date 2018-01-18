using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class ProcesosHumedos
    {
        public int Id { get; set; }
        public TimeSpan Fin { get; set; }
        public TimeSpan Inicio { get; set; }
        public int Proceso { get; set; }
        public int SubPartidaId { get; set; }

        public SubPartidas SubPartida { get; set; }
        public RecetaHumedas RecetaHumedas { get; set; }
    }
}
