using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class ItemSubProceso
    {
        public int ID { get; set; }
        public int SubProcesoID { get; set; }
        public int InsumoID { get; set; }
        public int Cantidad { get; set; }
        public decimal Porcentaje { get; set; }
        public decimal KgG { get; set; }

        public SubProceso SubProceso { get; set; }
        public Insumo Insumo { get; set; }
    }
}
