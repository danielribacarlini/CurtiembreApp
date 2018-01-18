using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Insumo
    {
        public int ID { get; set; }
        public int Descripcion { get; set; }
        public int Stock { get; set; }

        public ICollection<ItemReceta> ItemReceta { get; set; }

    }
}
