using State;

Orcamento reforma = new Orcamento(500);

Console.WriteLine(reforma.Valor);

reforma.AplicaDescontoExtra();
Console.WriteLine(reforma.Valor);

reforma.Aprova();
reforma.AplicaDescontoExtra();
Console.WriteLine(reforma.Valor);

reforma.Finaliza();

reforma.AplicaDescontoExtra();