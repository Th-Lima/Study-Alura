using Strategy;

IImposto iss = new ISS();
IImposto icms = new ICMS();

Orcamento orcamento = new Orcamento(500.0);

CalculadorDeImpostos calculador = new CalculadorDeImpostos();

calculador.RealizaCalculo(orcamento, iss);
calculador.RealizaCalculo(orcamento, icms);
