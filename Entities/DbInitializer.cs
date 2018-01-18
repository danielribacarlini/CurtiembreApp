using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public static class DbInitializer
    {
        public static void Initialize(Context context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Partidas.Any())
            {
                return;   // DB has been seeded
            }

            var partidas = new Partida[]
            {
                new Partida{PesoPromedio=10,Cantidad=5,Tipo="Vaca", FechaIngreso=DateTime.Parse("2005-09-01")},
                new Partida{PesoPromedio=9,Cantidad=7,Tipo="Toro", FechaIngreso=DateTime.Parse("2003-10-06")},
            
            };
            foreach (Partida p in partidas)
            {
                context.Partidas.Add(p);
            }
            context.SaveChanges();

            var subPartidas = new SubPartida[]
            {
                new SubPartida{PartidaID=1, CantCueros=3, Calidad=Calidad.Bueno, Estado="CURTIENDO"},
                new SubPartida{PartidaID=2, CantCueros=10, Calidad=Calidad.Malo, Estado="PELAMBRE"},
                new SubPartida{PartidaID=1, CantCueros=5, Calidad=Calidad.Regular, Estado="ENGRASE"},
            
            };
            foreach (SubPartida s in subPartidas)
            {
                context.SubPartidas.Add(s);
            }
            context.SaveChanges();

            var clientes = new Cliente[]
            {
                new Cliente{Nombre="Daniel",Direccion="Garibaldi 1273",Telefono="0567-34230"},
                new Cliente{Nombre="Florencia",Direccion="San Martin 987",Telefono="0457-234301"},           
            };
            foreach (Cliente c in clientes)
            {
                context.Clientes.Add(c);
            }
            context.SaveChanges();

            var pedidos = new Pedido[]
            {
                new Pedido{ClienteID=1},
                new Pedido{ClienteID=2}
            };
            foreach (Pedido p in pedidos)
            {
                context.Pedidos.Add(p);
            }
            context.SaveChanges();

            var procesosHumedos = new ProcesoHumedo[]
            {
                new ProcesoHumedo{SubPartidaID=1, Proceso=Proceso.Curtido, Inicio=TimeSpan.Parse("10:52"), Fin=TimeSpan.Parse("09:32")},
                new ProcesoHumedo{SubPartidaID=1, Proceso=Proceso.Curtido, Inicio=TimeSpan.Parse("16:23"), Fin=TimeSpan.Parse("11:45")}
            };
            foreach (ProcesoHumedo p in procesosHumedos)
            {
                context.ProcesosHumedos.Add(p);
            }
            context.SaveChanges();

            var operarios = new Operario[]
            {
                new Operario{Nombre="Daniel", Telefono="08984233"}
            };
            foreach (Operario o in operarios)
            {
                context.Operarios.Add(o);
            }
            context.SaveChanges();
        }
    }
}
