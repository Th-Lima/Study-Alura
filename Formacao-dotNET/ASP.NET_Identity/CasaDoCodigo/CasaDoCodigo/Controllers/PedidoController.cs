using CasaDoCodigo.Areas.Identity.Data;
using CasaDoCodigo.Models;
using CasaDoCodigo.Models.ViewModels;
using CasaDoCodigo.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CasaDoCodigo.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IProdutoRepository produtoRepository;
        private readonly IPedidoRepository pedidoRepository;
        private readonly UserManager<AppIdentityUser> _userManager;

        public PedidoController(IProdutoRepository produtoRepository,
            IPedidoRepository pedidoRepository, UserManager<AppIdentityUser> userManager)
        {
            this.produtoRepository = produtoRepository;
            this.pedidoRepository = pedidoRepository;
            this._userManager = userManager; 
        }

        public async Task<IActionResult> Carrossel()
        {
            return View(await produtoRepository.GetProdutosAsync());
        }

        //MELHORIA: 2) Nova view de Busca de Produtos
        //Para saber mais: Formação .NET
        //https://cursos.alura.com.br/formacao-dotnet
        public async Task<IActionResult> BuscaProdutos(string pesquisa)
        {
            return View(await produtoRepository.GetProdutosAsync(pesquisa));
        }

        [Authorize]
        public async Task<IActionResult> Carrinho(string codigo)
        {
            if (!string.IsNullOrEmpty(codigo))
            {
                await pedidoRepository.AddItemAsync(codigo);
            }

            var pedido = await pedidoRepository.GetPedidoAsync();
            List<ItemPedido> itens = pedido.Itens;
            CarrinhoViewModel carrinhoViewModel = new CarrinhoViewModel(itens);
            return base.View(carrinhoViewModel);
        }

        [Authorize]
        public async Task<IActionResult> Cadastro()
        {
            var pedido = await pedidoRepository.GetPedidoAsync();

            if (pedido == null)
            {
                return RedirectToAction("Carrossel");
            }

            var user = await _userManager.GetUserAsync(this.User);

            pedido.Cadastro.Email = user.Email;
            pedido.Cadastro.Telefone = user.Telefone;
            pedido.Cadastro.Nome = user.Nome;
            pedido.Cadastro.Endereco = user.Endereco;
            pedido.Cadastro.UF = user.UF;
            pedido.Cadastro.Complemento = user.Complemento;
            pedido.Cadastro.Bairro = user.Bairro;
            pedido.Cadastro.Municipio = user.Municipio;
            pedido.Cadastro.CEP = user.CEP;

            return View(pedido.Cadastro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Resumo(Cadastro cadastro)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(this.User);

                user.Email = cadastro.Email;
                user.Telefone = cadastro.Telefone;
                user.Nome = cadastro.Nome;
                user.Endereco = cadastro.Endereco;
                user.UF = cadastro.UF;
                user.Complemento = cadastro.Complemento;
                user.Bairro = cadastro.Bairro;
                user.Municipio = cadastro.Municipio;
                user.CEP = cadastro.CEP;

                await _userManager.UpdateAsync(user);
                
                return View(await pedidoRepository.UpdateCadastroAsync(cadastro));
            }
           
            return RedirectToAction("Cadastro");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<UpdateQuantidadeResponse> UpdateQuantidade([FromBody]ItemPedido itemPedido)
        {
            return await pedidoRepository.UpdateQuantidadeAsync(itemPedido);
        }
    }
}
