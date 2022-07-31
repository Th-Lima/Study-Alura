namespace Command.Cap7
{
    public class PagaPedido : IComando
    {
        private Pedido Pedido;

        public PagaPedido(Pedido pedido)
        {
            this.Pedido = pedido;
        }

        public void Executa()
        {
            Console.WriteLine($"Pagando o pedido do cliente {Pedido.Cliente}");
            Pedido.Paga();
        }
    }
}
