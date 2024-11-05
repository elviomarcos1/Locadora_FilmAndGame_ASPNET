using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Locadora_Filmes_e_Jogos.Data;
using Locadora_Filmes_e_Jogos.Models;

namespace Locadora_Filmes_e_Jogos.Controllers
{
    public class JogosController : Controller
    {
        private readonly applicationDbContext _context;

        public JogosController(applicationDbContext context)
        {
            _context = context;
        }

        // GET: Jogos
        public async Task<IActionResult> Index()
        {
            return View(await _context.jogos.ToListAsync());
        }

        // GET: Jogos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogos = await _context.jogos
                .FirstOrDefaultAsync(m => m.pk_jogo == id);
            if (jogos == null)
            {
                return NotFound();
            }

            return View(jogos);
        }

        // GET: Jogos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jogos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("pk_jogo,nome_jogo,classificacao_jogo,ano_lancamento_jogo,ativo_jogos")] Jogos jogos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jogos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jogos);
        }

        // GET: Jogos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogos = await _context.jogos.FindAsync(id);
            if (jogos == null)
            {
                return NotFound();
            }
            return View(jogos);
        }

        // POST: Jogos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("pk_jogo,nome_jogo,classificacao_jogo,ano_lancamento_jogo,ativo_jogos")] Jogos jogos)
        {
            if (id != jogos.pk_jogo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jogos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JogosExists(jogos.pk_jogo))
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
            return View(jogos);
        }

        // GET: Jogos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogos = await _context.jogos
                .FirstOrDefaultAsync(m => m.pk_jogo == id);
            if (jogos == null)
            {
                return NotFound();
            }

            return View(jogos);
        }

        // POST: Jogos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jogos = await _context.jogos.FindAsync(id);
            if (jogos != null)
            {
                _context.jogos.Remove(jogos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JogosExists(int id)
        {
            return _context.jogos.Any(e => e.pk_jogo == id);
        }
    }
}
