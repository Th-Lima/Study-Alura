﻿using CasaDoCodigo.Models;
using CasaDoCodigo.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CasaDoCodigo.Repositories
{
    public interface IPedidoRepository
    {
        Pedido GetPedido();
        void AddItem(string codigo);
        UpdateQuantidadeResponse UpdateQuantidade(ItemPedido itemPedido);
        Pedido UpdateCadastro(Cadastro cadastro);
    }


    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IItemPedidoRepository _itemPedidoRepository;
        private readonly ICadastroRepository _cadastroRepository;

        public PedidoRepository(AplicationContext context, IHttpContextAccessor contextAccessor, IItemPedidoRepository itemPedidoRepository, ICadastroRepository cadastroRepository) : base(context)
        {
            _contextAccessor = contextAccessor;
            _itemPedidoRepository = itemPedidoRepository;
            _cadastroRepository = cadastroRepository;
        }

        public void AddItem(string codigo)
        {
            var produto = _context.Set<Produto>().Where(x => x.Codigo == codigo).SingleOrDefault();

            if(produto == null)
            {
                throw new ArgumentException("Produto não encontrado");
            }

            var pedido = GetPedido();

            var itemPedido = _context.Set<ItemPedido>()
                .Where(x => x.Produto.Codigo == codigo && x.Pedido.Id == pedido.Id)
                .SingleOrDefault();

            if(itemPedido == null)
            {
                itemPedido = new ItemPedido(pedido, produto, 1, produto.Preco);
                _context.Set<ItemPedido>().Add(itemPedido);
                
                _context.SaveChanges();
            }
        }

        public Pedido GetPedido()
        {
            var pedidoId = this.GetPedidoId();
            var pedido = _dbSet
                .Include(x => x.Itens)
                .ThenInclude(x => x.Produto)
                .Include(x => x.Cadastro)
                .Where(x => x.Id == pedidoId)
                .SingleOrDefault();
            
            if (pedido == null)
            {
                pedido = new Pedido();
                _dbSet.Add(pedido);
                _context.SaveChanges();
               
                this.SetPedidoId(pedido.Id);
            }

            return pedido;
            
        }

        private int? GetPedidoId()
        {
            return _contextAccessor.HttpContext.Session.GetInt32("pedidoId");
        }

        private void SetPedidoId(int pedidoId)
        {
            _contextAccessor.HttpContext.Session.SetInt32("pedidoId", pedidoId);
        }

        public UpdateQuantidadeResponse UpdateQuantidade(ItemPedido itemPedido)
        {
            var itemPedidoDb = _itemPedidoRepository.GetItemPedido(itemPedido.Id);

            if (itemPedidoDb != null)
            {
                itemPedidoDb.AtualizaQuantidade(itemPedido.Quantidade);

                if(itemPedido.Quantidade == 0)
                {
                    _itemPedidoRepository.RemoveItemPedido(itemPedido.Id);
                }

                _context.SaveChanges();

                var carrinhoViewModel = new CarrinhoViewModel(GetPedido().Itens);
                return new UpdateQuantidadeResponse(itemPedidoDb, carrinhoViewModel);
            }

            throw new ArgumentException("ItemPedido não encontrado");
        }

        public Pedido UpdateCadastro(Cadastro cadastro)
        {
            var pedido = GetPedido();
            
            _cadastroRepository.Update(pedido.Cadastro.Id, cadastro);

            return pedido;
        }
    }
}
