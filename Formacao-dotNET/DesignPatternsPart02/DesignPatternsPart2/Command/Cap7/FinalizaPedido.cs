namespace Command.Cap7
{
    public class FinalizaPedido : IComando
    {
        private Pedido Pedido;

        public FinalizaPedido(Pedido pedido)
        {
            this.Pedido = pedido;
        }

        public void Executa()
        {
            Console.WriteLine($"Finalizando o pedido do cliente {Pedido.Cliente}");
            Pedido.Finaliza();
        }
    }
}
