using TemplateMethod;

CalculcadorDeDescontos calculador = new CalculcadorDeDescontos();

Orcamento orcamento = new Orcamento(500);
orcamento.AdicionaItem(new Item("CANETA", 250));
orcamento.AdicionaItem(new Item("LAPIS", 250));
orcamento.AdicionaItem(new Item("GELADEIRA", 250));
orcamento.AdicionaItem(new Item("FOGAO", 250));
orcamento.AdicionaItem(new Item("MICROONDAS", 250));
orcamento.AdicionaItem(new Item("TV", 250));

double desconto = calculador.Calcula(orcamento);
Console.WriteLine(desconto);