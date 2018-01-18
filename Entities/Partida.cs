using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Partida
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public decimal PesoPromedio { get; set; }
        public int Cantidad { get; set; }
        public int? CantSinClasificar { get; set; }
        public string Observaciones { get; set; }
        public string Tipo { get; set; }
        public  DateTime FechaIngreso { get; set; }

        public ICollection<SubPartida> SubPartidas { get; set; }

    }
}
