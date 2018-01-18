using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class ItemReceta
    {
        public int ID { get; set; }
        public int RecetaID { get; set; }
        public int InsumoID { get; set; }
        public int Cantidad { get; set; }
        public decimal Tiempo { get; set; }

        public RecetaHumeda RecetaHumeda { get; set; }
        public Insumo Insumo { get; set; }
    }
}
