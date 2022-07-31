using Visitor.Cap5;

var esquerda = new Soma(new Numero(1), new Numero(10));
var direita = new Subtracao(new Numero(20), new Numero(10));

var soma = new Soma(esquerda, direita);

Console.WriteLine(soma.Avalia());
ImpressoraVisitor impressora = new ImpressoraVisitor();
soma.Aceita(impressora);