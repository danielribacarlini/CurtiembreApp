using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class ItemsReceta
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public int InsumoId { get; set; }
        public int? RecetaHumedaId { get; set; }
        public int RecetaId { get; set; }
        public decimal Tiempo { get; set; }

        public Insumos Insumo { get; set; }
        public RecetaHumedas RecetaHumeda { get; set; }
    }
}
