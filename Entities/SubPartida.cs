using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public enum Calidad
    {
        Bueno,
        Malo,
        Regular
    }

    public class SubPartida
    {
   
        public int ID { get; set; }
        public int PartidaID { get; set; }
        public int? PedidoID { get; set; }
        public int CantCueros { get; set; }
        public Calidad  Calidad { get; set; }
        public string Estado { get; set; }
        public decimal? Eficiencia { get; set; }
        public int? Stock { get; set; }

        public Partida Partida { get; set; }
        public Pedido Pedido { get; set; }


    }
}
