using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Pedidos
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }

        public Clientes Cliente { get; set; }
        public SubPartidas SubPartidas { get; set; }
    }
}
