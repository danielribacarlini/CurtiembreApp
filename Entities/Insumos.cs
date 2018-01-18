using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Insumos
    {
        public Insumos()
        {
            ItemsReceta = new HashSet<ItemsReceta>();
        }

        public int Id { get; set; }
        public int Descripcion { get; set; }
        public int Stock { get; set; }

        public ICollection<ItemsReceta> ItemsReceta { get; set; }
    }
}
