using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Pedido
    {
        public int ID { get; set; }
        public int ClienteID { get; set; }

        public SubPartida SubPartida { get; set; }
        public Cliente Cliente { get; set; }
    }
}
