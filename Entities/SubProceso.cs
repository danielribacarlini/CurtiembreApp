using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class SubProceso
    {
        public int ID { get; set; }
        public int RecetaID { get; set; }
        public int ProcesoHumedoID { get; set; }
        public string Nombre { get; set; }
        public TimeSpan Tiempo { get; set; }
        public TimeSpan Inicio { get; set; }
        public TimeSpan Fin { get; set; }
        public decimal Ph { get; set; }
        public decimal Temp { get; set; }
        public decimal Be { get; set; }
        public string Observaciones { get; set; }

        public RecetaHumeda RecetaHumeda { get; set; }
        public ICollection<ItemSubProceso> ItemsSubProcesos { get; set; }

    }
}
