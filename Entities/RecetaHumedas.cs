using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class RecetaHumedas
    {
        public RecetaHumedas()
        {
            ItemsReceta = new HashSet<ItemsReceta>();
        }

        public int Id { get; set; }
        public int ProcesoHumedoId { get; set; }

        public ProcesosHumedos ProcesoHumedo { get; set; }
        public ICollection<ItemsReceta> ItemsReceta { get; set; }
    }
}
