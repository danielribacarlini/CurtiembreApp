using System;
using System.Collections.Generic;
using System.Linq;
using Entities;

namespace Services
{
    public class PartidasServices
    {
        private IRepository<Partida> _partidaRepository;
        private SubPartidasServices _subPartidaService;

 

        public PartidasServices(IRepository<Partida> repoPartida, SubPartidasServices subPartidasServices)
        {
            this._partidaRepository = repoPartida;
            this._subPartidaService = subPartidasServices;
            
        }


        public IEnumerable <Partida> GetAllId()
        {

            var partidas = _partidaRepository.GetAll();
            foreach (var partida in partidas)
            {
                
                partida.SubPartidas = _subPartidaService.GetByIdPartida(partida.ID).ToList();
                if(partida.SubPartidas.Count == 0)
                {
                    partida.SubPartidas = null;
                }
            }

            return partidas;
        }

        public Partida GetByID(int id)
        {
            return  _partidaRepository.Set().FirstOrDefault(x => x.ID == id);
        }

        public void Update(Partida partida)
        {
            _partidaRepository.Update(partida);
        }
    }
}
