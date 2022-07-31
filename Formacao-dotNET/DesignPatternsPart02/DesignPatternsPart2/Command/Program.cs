using Command.Cap7;

FilaDeTrabalho fila = new FilaDeTrabalho();
Pedido pedido1 = new Pedido("Thales", 100.0);
Pedido pedido2 = new Pedido("João", 500.0);
Pedido pedido3 = new Pedido("Lucas", 900.0);

fila.Adiciona(new PagaPedido(pedido1));
fila.Adiciona(new PagaPedido(pedido2));
fila.Adiciona(new PagaPedido(pedido3));

fila.Adiciona(new FinalizaPedido(pedido1));
fila.Adiciona(new FinalizaPedido(pedido2));
fila.Adiciona(new FinalizaPedido(pedido3));

fila.Processa();