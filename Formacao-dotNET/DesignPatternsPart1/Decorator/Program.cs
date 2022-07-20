using Decorator;

Imposto iss = new IKCV(new ICMS(new ICPP()));

Orcamento orcamento = new Orcamento(500);

double valor = iss.Calcula(orcamento);

Console.WriteLine(valor);