using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class RecetaHumeda
    {
        public int ID { get; set; }
        public int ProcesoHumedoID { get; set; }

        public ProcesoHumedo ProcesoHumedo { get; set; }
        public ICollection<ItemReceta> ItemsReceta { get; set; }
    }
}
