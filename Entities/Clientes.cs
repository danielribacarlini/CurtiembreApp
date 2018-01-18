using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Clientes
    {
        public Clientes()
        {
            Pedidos = new HashSet<Pedidos>();
        }

        public int Id { get; set; }
        public string Direccion { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }

        public ICollection<Pedidos> Pedidos { get; set; }
    }
}
