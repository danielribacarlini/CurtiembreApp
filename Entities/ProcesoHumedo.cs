using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public enum Proceso
    {
        Pelambre,
        Curtido,
        Engrase,
        Secado
    }

    public class ProcesoHumedo
    {
        public int ID { get; set; }
        public int SubPartidaID { get; set; }
        public Proceso Proceso { get; set; }
        public TimeSpan Inicio { get; set; }
        public TimeSpan Fin { get; set; }

        public SubPartida SubPartida { get; set; }
        public RecetaHumeda RecetaHumeda { get; set; }

    }
}
