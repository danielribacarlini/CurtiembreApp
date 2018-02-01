using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class SubPartidasServices
    {
        private IRepository<SubPartida> _subPartidaRepository;

        public SubPartidasServices()
        {
        }

        public SubPartidasServices(IRepository<SubPartida> repoSubPartida)
        {
            this._subPartidaRepository = repoSubPartida;
        }

        public IEnumerable<SubPartida> GetByIdPartida (int idPartida)
        {
            var subPartidas = _subPartidaRepository.GetAll().Where(x => x.PartidaID == idPartida);

            return subPartidas;
        }

        

    }
}
