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
        public async Task<IActionResult> FinalizarLocacao(int ClienteID, int FuncionarioID)
        {
            if (!ListaFilmes.Any() && !ListaJogos.Any() || ClienteID == 0 || FuncionarioID == 0)
            {
                TempData["AlertMessage"] = "Confira os campos de Funcionario e Cliente e lembre-se que seu carrinho não pode estar vazio!";
                return RedirectToAction("Index");
            }

            var novaLocacao = new Locacao()
            {
                fk_cliente = ClienteID,
                data_locacao = DateTime.Today,
                data_devolucao_prevista = DateTime.Today.AddDays(5),
                data_devolucao_real = null
            };

            _context.Add(novaLocacao);
            await _context.SaveChangesAsync();

            foreach (var filmeId in ListaFilmes)
            {
           
                var filme = await _context.filmes.FindAsync(filmeId);
                if (filme != null)
                {
                    var itemFilmeLocacao = new Item_filme_locacao()
                    {
                        fk_locacao = novaLocacao.pk_locacao,
                        fk_filme = filme.pk_filmes
                    };

                    _context.item_filme_locacao.Add(itemFilmeLocacao);
                }
            }

            foreach (var jogoId in ListaJogos)
            {
            
                var jogo = await _context.jogos.FindAsync(jogoId);
                if (jogo != null)
                {
                    var itemJogoLocacao = new Item_jogo_locacao()
                    {
                        fk_locacao = novaLocacao.pk_locacao,
                        fk_jogo = jogo.pk_jogo 
                    };

                    _context.item_jogo_locacao.Add(itemJogoLocacao);
                }
            }

            foreach (var filmeId in ListaFilmes)
            {
                var filme = await _context.filmes.FindAsync(filmeId);
                if (filme != null)
                {
                    filme.ativo_filmes = "N";
                }
            }

            foreach (var jogoId in ListaJogos)
            {
                var jogo = await _context.jogos.FindAsync(jogoId);
                if (jogo != null)
                {
                    jogo.ativo_jogos = "N";
                }
            }

            await _context.SaveChangesAsync();

            ListaFilmes.Clear();
            ListaJogos.Clear();

            return RedirectToAction("Pedido", "Locacao2", new { id = novaLocacao.pk_locacao });
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

        public async Task<IActionResult> Pedido(int ID)
        {
            // Buscar a locação
            var locacao = await _context.Locacao
                .Include(l => l.Cliente)  // Carregar os dados do cliente
                .FirstOrDefaultAsync(l => l.pk_locacao == ID);

            if (locacao == null)
            {
                return NotFound();  // Se a locação não for encontrada
            }

            // Obter a lista de filmes e jogos associados à locação
            var filmesLocacao = await _context.item_filme_locacao
                .Where(ifl => ifl.fk_locacao == ID)
                .Include(ifl => ifl.Filme)
                .Select(ifl => ifl.Filme)
                .ToListAsync();

            var jogosLocacao = await _context.item_jogo_locacao
                .Where(ijl => ijl.fk_locacao == ID)
                .Include(ijl => ijl.Jogo)
                .Select(ijl => ijl.Jogo)
                .ToListAsync();

            // Criar o ViewModel
            var viewModel = new PedidoViewModel
            {
                NumeroLocacao = locacao.pk_locacao,
                NomeCliente = locacao.Cliente.nome_cliente,
                DataLocacao = locacao.data_locacao,
                DataDevolucaoPrevista = locacao.data_devolucao_prevista,
                Filmes = filmesLocacao,
                Jogos = jogosLocacao
            };

            // Retornar a view com o ViewModel
            return View(viewModel);
        }

    }
}
