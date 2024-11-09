using Locadora_Filmes_e_Jogos.Data;
using Locadora_Filmes_e_Jogos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Locadora_Filmes_e_Jogos.Controllers
{
    public class Locacao2Controller : Controller
    {
        private static List<int> ListaFilmes = new List<int>();
        private static List<int> ListaJogos = new List<int>();
        private readonly applicationDbContext _context;
        
        //Get Index
        public Locacao2Controller(applicationDbContext context)
        {
            _context = context;
        }

        //Get Locação
        public async Task<IActionResult> Index()
        {
            var model = new LocacaoViewModel
            {
                Filmes = _context.filmes.ToList().Where(f => f.ativo_filmes.Contains("S")),
                Jogos = _context.jogos.ToList().Where(j => j.ativo_jogos.Contains("S")),
                Clientes = _context.cliente.ToList().Where(c => c.ativo_cliente.Contains("S")),
                Funcionarios = _context.funcionario.ToList().Where(f => f.ativo_funcionario.Contains("S"))
            };
            
            return View(model);
        }

        //Function Locação
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Alugar(int IndexFilme, int IndexJogo)
        {
            // Adiciona o filme à lista
            ListaFilmes.Add(IndexFilme);
            ListaJogos.Add(IndexJogo);

            var filme = await _context.filmes.FindAsync(IndexFilme);
            if(filme != null)
            {
                filme.ativo_filmes = "N";
                await _context.SaveChangesAsync();
            }

            var jogo = await _context.jogos.FindAsync(IndexJogo);
            if (jogo != null)
            {
                jogo.ativo_jogos = "N";
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FinalizarLocacao()
        {
            if (!ListaFilmes.Any() || !ListaJogos.Any())
            {
                TempData["AlertMessage"] = "Error as Listas estão Vazias";
                return RedirectToAction("Index");
            }
            return Content("Enviando");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CancelarLocacao()
        {
            var FilmesParaCancelar = await _context.filmes
                .Where(f => ListaFilmes.Contains(f.pk_filmes))
                .ToListAsync();
            foreach (var f in FilmesParaCancelar)
            {
                f.ativo_filmes = "S";
            }

            var JogosParaCancelar = await _context.jogos
                .Where(j => ListaJogos.Contains(j.pk_jogo))
                .ToListAsync();
            foreach (var j in JogosParaCancelar)
            {
                j.ativo_jogos = "S";
            }

            await _context.SaveChangesAsync();

            ListaFilmes.Clear();
            ListaJogos.Clear();

            return RedirectToAction("Index");
        }
    }
}
