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
    public class PartidasController : Controller
    {
        private readonly Context _context;
        private PartidasServices _partidasServices;
        

        public PartidasController(Context context, PartidasServices partidasServices)
        {
            _context = context;
            _partidasServices = partidasServices;

        }

        // GET: Partidas
        public async Task<IActionResult> Index()
        {
            return View( _partidasServices.GetAllId());

            //return View(await _context.Partidas.ToListAsync());
        }

        // GET: Partidas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partida = await _context.Partidas
                .SingleOrDefaultAsync(m => m.ID == id);
            if (partida == null)
            {
                return NotFound();
            }

            return View(partida);
        }

        // GET: Partidas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Partidas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,PesoPromedio,Cantidad,Observaciones,Tipo,FechaIngreso")] Partida partida)
        {
            if (ModelState.IsValid)
            {
                partida.CantSinClasificar = partida.Cantidad;
                _context.Add(partida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(partida);
        }

        // GET: Partidas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partida = await _context.Partidas.SingleOrDefaultAsync(m => m.ID == id);
            if (partida == null)
            {
                return NotFound();
            }
            return View(partida);
        }

        // POST: Partidas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,PesoPromedio,Cantidad,CantSinClasificar,Observaciones,Tipo,FechaIngreso")] Partida partida)
        {
            if (id != partida.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartidaExists(partida.ID))
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
            return View(partida);
        }

        // GET: Partidas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partida = await _context.Partidas
                .SingleOrDefaultAsync(m => m.ID == id);
            if (partida == null)
            {
                return NotFound();
            }

            return View(partida);
        }

        // POST: Partidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var partida = await _context.Partidas.SingleOrDefaultAsync(m => m.ID == id);
            _context.Partidas.Remove(partida);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartidaExists(int id)
        {
            return _context.Partidas.Any(e => e.ID == id);
        }
    }
}
