using CasaDoCodigo.Models;
using System.Linq;

namespace CasaDoCodigo.Repositories
{
    public interface IItemPedidoRepository
    {
        ItemPedido GetItemPedido(int itemPedidoId);
        void RemoveItemPedido(int itemPedidoId);
    }

    public class ItemPedidoRepository : BaseRepository<ItemPedido>, IItemPedidoRepository
    {
        public ItemPedidoRepository(AplicationContext context) : base(context)
        {
        }

        public ItemPedido GetItemPedido(int itemPedidoId)
        {
           return _dbSet
                .Where(x => x.Id == itemPedidoId)
                .SingleOrDefault();
        }

        public void RemoveItemPedido(int itemPedidoId)
        {
            _dbSet.Remove(this.GetItemPedido(itemPedidoId));
        }
    }
}
