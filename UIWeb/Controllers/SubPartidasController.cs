using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entities;
using Services;

namespace UIWeb.Controllers
{
    public class SubPartidasController : Controller
    {
        private readonly Context _context;
        private SubPartidasServices _subPartidaServices;
        private PartidasServices _partidasServices;

        public SubPartidasController(Context context, SubPartidasServices subPartidaServices, PartidasServices partidasServices)
        {
            _context = context;
            _subPartidaServices = subPartidaServices;
            _partidasServices = partidasServices;
        }

        // GET: SubPartidas
        public async Task<IActionResult> Index(int? id)
        {
            ViewData["PartidaID"] = id;
            var cantSinClasificar = _context.Partidas.Where(x => x.ID == id).Select(x=> x.CantSinClasificar).FirstOrDefault();
            ViewData["CantSinClasificar"] = cantSinClasificar;
            var context = _context.SubPartidas.Include(s => s.Partida).Where(s => s.PartidaID == id).Include(s => s.Pedido);
            return View(await context.ToListAsync());
        }

        // GET: SubPartidas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subPartida = await _context.SubPartidas
                .Include(s => s.Partida)
                .Include(s => s.Pedido)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (subPartida == null)
            {
                return NotFound();
            }

            return View(subPartida);
        }

        // GET: SubPartidas/Create
        public IActionResult Create(int? ID)
        {
            ViewData["PartidaID"] = ID;
            //ViewData["PartidaID"] = new SelectList(_context.Partidas, "ID", "ID");
            ViewData["PedidoID"] = new SelectList(_context.Pedidos, "ID", "ID");
            return View();
        }

        // POST: SubPartidas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PartidaID,PedidoID,CantCueros,Calidad,Estado,Eficiencia,Stock")] SubPartida subPartida)
        {
            if (ModelState.IsValid)
            {

                var partida = await _context.Partidas.FirstOrDefaultAsync(x => x.ID == subPartida.PartidaID);
                partida.CantSinClasificar = partida.CantSinClasificar - subPartida.CantCueros;
                _context.Add(subPartida);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { id = subPartida.PartidaID });
            }
            ViewData["PartidaID"] = new SelectList(_context.Partidas, "ID", "ID", subPartida.PartidaID);
            ViewData["PedidoID"] = new SelectList(_context.Pedidos, "ID", "ID", subPartida.PedidoID);
            return RedirectToAction("Index", new { id = subPartida.PartidaID });
        }

        // GET: SubPartidas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subPartida = await _context.SubPartidas.SingleOrDefaultAsync(m => m.ID == id);
            if (subPartida == null)
            {
                return NotFound();
            }
            ViewData["PartidaID"] = new SelectList(_context.Partidas, "ID", "ID", subPartida.PartidaID);
            ViewData["PedidoID"] = new SelectList(_context.Pedidos, "ID", "ID", subPartida.PedidoID);
            return View(subPartida);
        }

        // POST: SubPartidas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,PartidaID,PedidoID,CantCueros,Calidad,Estado,Eficiencia,Stock")] SubPartida subPartida)
        {
            if (id != subPartida.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subPartida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubPartidaExists(subPartida.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PartidaID"] = new SelectList(_context.Partidas, "ID", "ID", subPartida.PartidaID);
            ViewData["PedidoID"] = new SelectList(_context.Pedidos, "ID", "ID", subPartida.PedidoID);
            return View(subPartida);
        }

        // GET: SubPartidas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subPartida = await _context.SubPartidas
                .Include(s => s.Partida)
                .Include(s => s.Pedido)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (subPartida == null)
            {
                return NotFound();
            }

            return View(subPartida);
        }

        // POST: SubPartidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, int PartidaID, int CantCueros)
        {
            var partida = _partidasServices.GetByID(PartidaID);
            partida.CantSinClasificar = partida.CantSinClasificar + CantCueros;
            _partidasServices.Update(partida);


            var subPartida = await _context.SubPartidas.SingleOrDefaultAsync(m => m.ID == id);
            _context.SubPartidas.Remove(subPartida);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { id = subPartida.PartidaID });
        }

        private bool SubPartidaExists(int id)
        {
            return _context.SubPartidas.Any(e => e.ID == id);
        }
    }
}
